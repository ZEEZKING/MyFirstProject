using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Interface
{
    public interface IManagerManager
    {
         Manager Register(string firstname,string lastname, string email, string password, string phonenumber, string Address, Gender gender);
        Manager Get(string userEmail);
        List<Manager> GetAll();
    
    }
}