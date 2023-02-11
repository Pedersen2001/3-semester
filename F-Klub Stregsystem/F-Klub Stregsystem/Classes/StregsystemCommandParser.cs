using F_Klub_Stregsystem.Exceptions;
using F_Klub_Stregsystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Klub_Stregsystem.Classes
{
    public class StregsystemCommandParser
    {
        private delegate void adminCommand(string[] command);
        private Dictionary<string, adminCommand> adminCommands = new Dictionary<string, adminCommand>();


        public StregsystemCommandParser(IStregsystem stregsystem, IStregsystemUI stregsystemUi)
        {
            Stregsystem = stregsystem;
            StregsystemUI = stregsystemUi;
            GenerateAdminCommands();
            stregsystemUi.CommandEntered += ParseCommand;
            stregsystem.UserBalanceWarning += UserNotification;
        }
        private IStregsystem Stregsystem { get; }
        private IStregsystemUI StregsystemUI { get; }

        private void GenerateAdminCommands()
        {
            adminCommands.Add(":q", x => StregsystemUI.Finish());
            adminCommands.Add(":quit", x => StregsystemUI.Finish());
            adminCommands.Add(":activate", id => SetProductActive(id));
            adminCommands.Add(":deactivate", id => SetProductInactive(id));
            adminCommands.Add(":crediton", id => SetProductCreditOn(id));
            adminCommands.Add(":creditoff", id => SetProductCreditOff(id));
            adminCommands.Add(":addcredits", command => AddCreditsToUser(command));
        }
        private void ParseCommand(string input)
        {
            if (input.StartsWith(":"))
            {
                ParseAdminCommand(input);
            }
            else
                ParseUserCommand(input);
        }
        private void ParseAdminCommand(string command)
        {
            string[] splitCommand = command.Split(" ");
            if (adminCommands.ContainsKey(splitCommand[0]))
            {
                adminCommands[splitCommand[0]]?.Invoke(splitCommand);
            }
            else
                StregsystemUI.DisplayAdminCommandNotFoundMessage(command);
        }
        private void ParseUserCommand(string command)
        {
            string[] splitCommand = command.Split(" ");
            switch (splitCommand.Length)
            {
                case 1:
                    DisplayUserInfo(splitCommand[0]);
                    break;
                case 2:
                    BuyProduct(splitCommand);
                    break;
                case 3:
                    BuyMultipleProducts(splitCommand);
                    break;
                default:
                    StregsystemUI.DisplayTooManyArgumentsError(command);
                    break;
            }
        }

        private void BuyMultipleProducts(string[] command)
        {
            try
            {
                User user = Stregsystem.GetUserByUsername(command[0]);
                int count = int.Parse(command[1]);
                Product product = Stregsystem.GetProductByID(int.Parse(command[2]));
                BuyTransaction buyTransaction = null;
                if (user.Balance < (count * product.Price))
                {
                    StregsystemUI.DisplayInsufficientCash(user, product);
                }
                if (count < 1)
                {
                    throw new NotSupportedException();
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        buyTransaction = Stregsystem.BuyProduct(user, product);
                    }
                    StregsystemUI.DisplayUserBuysProduct(buyTransaction);
                }
            }
            catch (NotSupportedException)
            {
                StregsystemUI.DisplayGeneralError("Amount has to be greater than 1");
            }
            catch (ProductDoesNotExistException)
            {
                StregsystemUI.DisplayProductNotFound(command[2]);
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUI.DisplayUserNotFound(command[0]);
            }
            catch (ProductNotActiveException)
            {
                StregsystemUI.DisplayGeneralError("The product in question is no longer active, and can not be bought");
            }
            catch (InsufficientCreditsException)
            {
                StregsystemUI.DisplayGeneralError("You do not have enough money to buy the product in question");
            }
            catch (ArgumentException)
            {
                StregsystemUI.DisplayGeneralError("Input was invalid");
            }
        }

        private void BuyProduct(string[] command)
        {
            try
            {
                User user = Stregsystem.GetUserByUsername(command[0]);
                Product product = Stregsystem.GetProductByID(int.Parse(command[1]));
                BuyTransaction buyTransaction = Stregsystem.BuyProduct(user, product);
                StregsystemUI.DisplayUserBuysProduct(buyTransaction);
            }
            catch (ProductDoesNotExistException)
            {
                StregsystemUI.DisplayProductNotFound(command[1]);
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUI.DisplayUserNotFound(command[0]);
            }
            catch (ProductNotActiveException)
            {
                StregsystemUI.DisplayGeneralError("The product in question is no longer active, and can not be bought");
            }
            catch (InsufficientCreditsException)
            {
                StregsystemUI.DisplayGeneralError("You do not have enough money to buy the product in question");
            }
            catch (ArgumentException)
            {
                StregsystemUI.DisplayGeneralError("Input was invalid");
            }
        }
        private void DisplayUserInfo(string username)
        {
            try
            {
                User user = Stregsystem.GetUserByUsername(username);
                StregsystemUI.DisplayUserInfo(user);
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUI.DisplayGeneralError("The user does not exist");
            }
        }
        private void SetProductActive(string[] command)
        {
            try
            {
                int id = int.Parse(command[1]);
                Product product = Stregsystem.GetProductByID(id);
                product.Active = true;
            }
            catch (ArgumentException)
            {
                StregsystemUI.DisplayGeneralError("Invalid input");
            }
        }

        private void SetProductInactive(string[] command)
        {
            try
            {
                int id = int.Parse(command[1]);
                Product product = Stregsystem.GetProductByID(id);
                product.Active = false;
            }         
            catch (ArgumentException)
            {
                StregsystemUI.DisplayGeneralError("Invalid input");
            }
        }
        private void SetProductCreditOn(string[] command)
        {
            try
            {
                int id = int.Parse(command[1]);
                Product product = Stregsystem.GetProductByID(id);
                product.CanBeBoughtOnCredit = true;
            }
            catch (ProductDoesNotExistException)
            {
                StregsystemUI.DisplayGeneralError("The product does not exist");
            }
            catch (ArgumentException)
            {
                StregsystemUI.DisplayGeneralError("Invalid input");
            }
        }
        private void SetProductCreditOff(string[] command)
        {
            try
            {
                int id = int.Parse(command[1]);
                Product product = Stregsystem.GetProductByID(id);
                product.CanBeBoughtOnCredit = false;
            }
            catch (ProductDoesNotExistException)
            {
                StregsystemUI.DisplayGeneralError("The product does not exist");
            }
            catch (ArgumentException)
            {
                StregsystemUI.DisplayGeneralError("Invalid input");
            }
        }

        private void AddCreditsToUser(string[] command)
        {
            try
            {
                User user = null;
                decimal amount = 0;
                user = Stregsystem.GetUserByUsername(command[1]);
                amount = decimal.Parse(command[2]);
                Stregsystem.AddCreditsToAccount(user, amount);
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUI.DisplayGeneralError("User does not exist");
            }
            catch (ArgumentException)
            {
                StregsystemUI.DisplayGeneralError("ID failed to parse");
            }

        }
        public void UserNotification(User user, decimal balance)
        {
            StregsystemUI.DisplayLowBalance(user, balance);
        }
    }
}

