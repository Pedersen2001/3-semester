using F_Klub_Stregsystem.Interfaces;

namespace F_Klub_Stregsystem.Classes
{
    public class Transaction
    {
        public int ID;
        public User User { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public Transaction(User user, DateTime date, decimal amount, IIdProvider idProvider)
        {
            ID = idProvider.NextId();
            User = user;
            Date = date;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"Transaction ID: { ID}, User: { User.UserName}, Amount: { Amount}, New Balance: { User.Balance}, Date: { Date}";
        }

        public virtual void Execute()
        {
            Console.WriteLine("Transaction executed.");
        }

    }
}
