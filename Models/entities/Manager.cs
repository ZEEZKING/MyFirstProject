namespace Hotel_App.Models.entities
{
    public class Manager : BaseEntity
    {
        public string userEmail;

        public Manager(int id, string Useremail,bool isDeleted) : base(id,isDeleted)
        {
            userEmail = Useremail;
            
        }
    }
}