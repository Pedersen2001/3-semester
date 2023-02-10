using F_Klub_Stregsystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Klub_Stregsystem.Exceptions
{
    class UserDoesNotExistException : Exception
    {
        public User User { get; }
        public UserDoesNotExistException()
        {

        }

        public UserDoesNotExistException(string message) : base(message)
        {

        }
        public UserDoesNotExistException(string message, Exception inner) : base(message, inner)
        {

        }

        public UserDoesNotExistException(string message, User user) : base(message)
        {
            User = user;
        }
    }
}
