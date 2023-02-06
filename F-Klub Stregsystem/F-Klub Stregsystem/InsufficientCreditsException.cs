namespace F_Klub_Stregsystem
{
    class InsufficientCreditsException : Exception
    {
        public User User { get; set; }
        public Product Product { get; set; }

        public InsufficientCreditsException()
        {

        }

        public InsufficientCreditsException(string message) : base(message)
        {

        }

        public InsufficientCreditsException(string message, Exception inner) : base(message, inner)
        {

        }

        public InsufficientCreditsException(string message, User user, Product product) : base(message)
        {
            Product = product;
            User = user;
        }
    }
}
