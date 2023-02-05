namespace F_Klub_Stregsystem
{
    internal partial class Program
    {
        class Transaction
        {
            static int IDCounter = 0;
            public int ID;
            public User User { get; set; }
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }

            public Transaction(User user, DateTime date, decimal amount)
            {
                ID = ++IDCounter;

                if (user == null)
                {
                    throw new ArgumentNullException("User can not be null");
                } 
                else
                {
                    User = user;
                }

                Date = date;
                Amount = amount;
            }

            public override string ToString()
            {
                return "Transaction ID: " + ID + ", User: " + User.UserName + ", Amount: " + Amount + ", Date: " + Date;
            }

            public virtual void Execute()
            {
                Console.WriteLine("Transaction executed.");
            }
        }
    }
}
