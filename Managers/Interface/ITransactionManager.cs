using System.Transactions;

namespace Hotel_App.Managers.Interface
{
    public interface ITransactionManager
    {
         Transaction Get(string Transactionrefno);
         List<Transaction> GetAll();
         bool Delete(string Transactionrefno);
    }
}