namespace F_Klub_Stregsystem
{

    
    class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, DateTime date, decimal amount) : base(user, date, amount)
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
