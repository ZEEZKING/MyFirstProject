using System.Transactions;
using Hotel_App.Managers.Interface;

namespace Hotel_App.Managers.Implementation
{
    public class TransactionManager : ITransactionManager
    {
        public static List<Transaction> transactionDb = new List<Transaction>();
        public bool Delete(string Transactionrefno)
        {
            throw new NotImplementedException();
        }

        public Transaction Get(string Transactionrefno)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }
        
    }
}