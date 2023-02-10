using F_Klub_Stregsystem.Interfaces;

namespace F_Klub_Stregsystem.Classes
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, DateTime date, decimal amount, IIdProvider idProvider) : base(user, date, amount, idProvider)
        {
        }
        public override string ToString()
        {
            return "Insert Cash Transaction: " + base.ToString();
        }

        public override void Execute()
        {
            User.Balance += Amount;
            Console.WriteLine("Insert cash transaction executed. New balance: " + User.Balance);
        }
    }
}
