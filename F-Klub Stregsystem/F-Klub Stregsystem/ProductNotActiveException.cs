namespace F_Klub_Stregsystem
{
    class ProductNotActiveException : Exception
    {
        public User User { get; set; }
        public Product Product { get; set; }

        public ProductNotActiveException()
        {

        }

        public ProductNotActiveException(string message) : base(message)
        {

        }

        public ProductNotActiveException(string message, Exception inner) : base(message, inner)
        {

        }

        public ProductNotActiveException(string message, User user, Product product) : base(message)
        {
            Product = product;
            User = user;
        }
    }
}
