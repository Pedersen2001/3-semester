namespace F_Klub_Stregsystem.Interfaces
{
    public interface IIdProvider
    {
        public int NextId();
        public int TryId(int getThis);
    }
}