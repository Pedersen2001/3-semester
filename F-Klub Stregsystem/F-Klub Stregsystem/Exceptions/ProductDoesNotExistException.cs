using F_Klub_Stregsystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Klub_Stregsystem.Exceptions
{
    class ProductDoesNotExistException : Exception
    {
        public Product Product { get; }
        public ProductDoesNotExistException()
        {

        }

        public ProductDoesNotExistException(string message) : base(message)
        {

        }
        public ProductDoesNotExistException(string message, Exception inner) : base(message, inner)
        {

        }

        public ProductDoesNotExistException(string message, Product product) : base(message)
        {
            Product = product;
        }
    }
}
