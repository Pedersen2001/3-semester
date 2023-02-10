using F_Klub_Stregsystem.Exceptions;
using F_Klub_Stregsystem.Interfaces;


namespace F_Klub_Stregsystem.Classes
{
    public class Stregsystem : IStregsystem
    {
        private List<Product> _products;
        private List<Transaction> _transactions = new List<Transaction>();
        private List<User> _users;
        private IIdProvider _transactionIdProvider;

        public event User.UserBalanceNotification UserBalanceWarning;

        public Stregsystem(List<Product> products, List<User> users, IIdProvider transactionIdProvider)
        {
            _products = products;
            _transactionIdProvider = transactionIdProvider;
            _users = users;
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction transaction = new BuyTransaction(user, product, DateTime.Now, _transactionIdProvider);
            ExecuteTransaction(transaction);

            if (user.Balance < 50)
            {
                UserBalanceWarning.Invoke(user, user.Balance);
            }

            return transaction;
        }

        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(user, DateTime.Now, amount, _transactionIdProvider);
            ExecuteTransaction(transaction);
            return transaction;
        }

        public List<User> GetUsers(Func<User, bool> predicate)
        {
            return _users.Where(predicate).ToList();
        }

        public User GetUserByUsername(string username)
        {
            User user = _users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                throw new UserDoesNotExistException($"{username.ToString()} does not exist");
            }
            return user;
        }

        public IEnumerable<Product> ActiveProducts
        {
            get
            {
                return _products.Where(p => p.Active).ToList();
            }
        }

        public Product GetProductByID(int id)
        {
            Product product = _products.FirstOrDefault(x => x.ID == id);

            if (product == null)
            {
                throw new Exception("The product with ID: " + id + " does not exist within the system");
            }

            return product;
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            return _transactions.Where(x => x.User == user).Take(count);
        }

        private void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);

            using StreamWriter sw = File.AppendText(@"C:\Users\lucas\GitRepos\3-semester\F-Klub Stregsystem\F-Klub Stregsystem\files\log.txt");
            sw.WriteLine(transaction.ToString());
        }
    }
}
