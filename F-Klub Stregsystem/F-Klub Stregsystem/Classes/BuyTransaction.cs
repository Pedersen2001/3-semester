using F_Klub_Stregsystem.Exceptions;
using F_Klub_Stregsystem.Interfaces;

namespace F_Klub_Stregsystem.Classes
{
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(User user, Product product, DateTime date, IIdProvider idProvider) : base(user, date, product.Price, idProvider)
        {
            Product = product;
        }

        public Product Product { get; set; }

        

        public override string ToString()
        {
            return $"Buy Transaction: {base.ToString()}, Product: + {Product.Name}";
        }

        public override void Execute()
        {
            if (User.Balance <= Amount && !Product.CanBeBoughtOnCredit)
            {
                throw new InsufficientCreditsException("You do not have enough money to buy the product in question: " + Product.Name, User, Product);

            }

            if (!Product.Active)
            {
                throw new ProductNotActiveException("The product in question is no longer active, and can not be bought: " + Product.Name, User, Product);
            }

            User.Balance -= Amount;
        }
    }
}
