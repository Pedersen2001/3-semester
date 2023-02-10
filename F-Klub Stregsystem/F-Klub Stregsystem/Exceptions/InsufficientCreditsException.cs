using F_Klub_Stregsystem.Classes;

namespace F_Klub_Stregsystem.Exceptions
{
    class InsufficientCreditsException : Exception
    {
        public User User { get; }
        public Product Product { get; }

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
