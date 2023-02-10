using F_Klub_Stregsystem.Classes;
using F_Klub_Stregsystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace F_Klub_Stregsystem.FileReader
{
    public class ReadProductsFile
    {
        public List<Product> Parse(IEnumerable<string> lines, IIdProvider idProvider)
        {
            List<Product> products = new List<Product>();

            foreach (string line in lines)
            {
                string[] values = line.Split(';');

                int id = Convert.ToInt32(values[0]);
                string name = Regex.Replace(values[1].Replace("\"", ""), "<.*?>", "");
                decimal price = Convert.ToInt32(values[2]);
                bool isActive = Convert.ToBoolean(Convert.ToInt32(values[3]));

                Product product = new Product(id, idProvider, name, price, isActive, false);
                products.Add(product);
            }

            return products;
        }
    }
}
