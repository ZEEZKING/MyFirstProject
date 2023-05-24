namespace Hotel_App.Models.entities
{
    public class Transaction : BaseEntity
    {
        public double transactionRefNo;
        public int CustomerId;
        public decimal amount;


        public Transaction(int id, double TransactionrefNo, int customerId, decimal Amount,bool isDeleted) : base(id,isDeleted)
        {
            transactionRefNo = TransactionrefNo;
            CustomerId = customerId;
            amount = Amount;
        }
    }
}