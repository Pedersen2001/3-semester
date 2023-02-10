using F_Klub_Stregsystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Klub_Stregsystem.Classes
{
    public class StregsystemUI : IStregsystemUI
    {
        public bool running = false;

        public IStregsystem Stregsystem { get; private set; }

        public delegate void StregsystemEvent(string input);

        public event StregsystemEvent CommandEntered;

        public StregsystemUI (IStregsystem stregsystem)
        {
            Stregsystem = stregsystem;
        }

        public void Start()
        {
            running = true;

            while (running)
            {
                DisplayActiveProducts();
                Console.WriteLine("Please enter a command: ");
                string userInput = Console.ReadLine();
                Console.Clear();
                CommandEntered?.Invoke(userInput);
            }
        }

        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine("User " + username + " not found!");
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine("Product " + product + " not found!");
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine("User info:");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
            Console.WriteLine($"Username: {user.UserName}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Balance: {user.Balance}");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString);
        }

        private void DisplayActiveProducts()
        {
            IEnumerable<Product> ActiveProducts = Stregsystem.ActiveProducts;
            foreach (Product product in ActiveProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine("Your balance (" + user.Balance + ") is too low to buy " + product.Name + " (Price: " + product.Price + ")");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine("Error " + "\"" + errorString + "\"" + " occurred");
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine("Command " + command + " has too many arguments");
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine("Admin command " + adminCommand + " not found!");
        }

        public void DisplayLowBalance(User user, decimal balance)
        {
            Console.WriteLine("User " + user.UserName + " has a balance below 50 stregdollars " + "(User balance: " + balance + ")");
        }

        public void Finish()
        {
            running = false;
            Environment.Exit(0);
        }

    }
}
