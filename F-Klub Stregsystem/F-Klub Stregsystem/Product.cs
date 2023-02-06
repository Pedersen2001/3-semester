namespace F_Klub_Stregsystem
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Product(int id, string name, decimal price, bool active = true, bool canBeBoughtOnCredit = true)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be greater than 1");
            }
                
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name must not be null or empty");
            }
                
            ID = id;
            Name = name;
            Price = price;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Price: {Price}";
        }
    }
}