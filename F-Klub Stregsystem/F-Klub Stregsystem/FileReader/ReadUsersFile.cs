using F_Klub_Stregsystem.Classes;
using F_Klub_Stregsystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Klub_Stregsystem.FileReader
{
    public class ReadUsersFile
    {
        public List<User> Parse(IEnumerable<string> lines, IIdProvider idProvider)
        {
            List<User> users = new List<User>();

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                int id = Convert.ToInt32(values[0]);

                string firstName = values[1];
                string lastName = values[2];
                string username = values[3];
                decimal balance = Convert.ToInt32(values[4]);
                string email = values[5];

                User user = new User(id, idProvider, firstName, lastName, email, username, balance);
                users.Add(user);
            }

            return users;
        }
    }
}
