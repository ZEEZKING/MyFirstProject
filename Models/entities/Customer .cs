namespace Hotel_App.Models.entities
{
    public class Customer : BaseEntity
    {
        public string UserEmail;
        public double Wallet;
      

        public Customer(int id,  string userEmail,double wallet,bool isDeleted) : base(id, isDeleted)
        {
            UserEmail = userEmail;
            Wallet = wallet;
             

            
        }
    }
}