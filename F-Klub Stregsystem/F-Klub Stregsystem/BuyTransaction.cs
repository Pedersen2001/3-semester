namespace F_Klub_Stregsystem
{
    class BuyTransaction : Transaction
    {
        public Product Product { get; set; }

        public BuyTransaction(User user, DateTime date, decimal amount, Product product) : base(user, date, amount)
        {
            Product = product;
        }

        public override string ToString()
        {
            return "Buy Transaction: " + base.ToString() + ", Product: " + Product.Name;
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
