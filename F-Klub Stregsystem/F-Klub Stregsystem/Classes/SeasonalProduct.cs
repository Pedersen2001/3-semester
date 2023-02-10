namespace F_Klub_Stregsystem.Classes
{
    public class SeasonalProduct : Product
    {
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }

        public SeasonalProduct(int id, IdProvider idProvider, string name, decimal price, bool active, bool canBeBoughtOnCredit, DateTime seasonStartDate, DateTime seasonEndDate) : base(id, idProvider, name, price, active, canBeBoughtOnCredit)
        {
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }

    }
}