using F_Klub_Stregsystem.Interfaces;

namespace F_Klub_Stregsystem.Classes
{
    public class Product
    {
        private int _id;
        private string _name;
        private decimal _price;

        public int ID { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public decimal Price { get { return _price; } set { _price = value; } }
        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Product(int id, IIdProvider idProvider, string name, decimal price, bool active, bool canBeBoughtOnCredit = true)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be greater than 1");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name must not be null or empty");
            }

            _id = idProvider.TryId(id);
            _name = name;
            _price = price;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Price: {Price}";
        }
    }
}