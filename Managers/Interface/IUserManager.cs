using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Interface
{
    public interface IUserManager
    {
         User Login(string email, string password);
         User Get(string email);
         List<User> GetAll();

    }
}