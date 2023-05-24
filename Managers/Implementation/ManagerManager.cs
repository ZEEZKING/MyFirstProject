using Hotel_App.Managers.Interface;
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Implementation
{
    public class ManagerManager : IManagerManager
    {
        IUserManager userManager = new UserManager();
        public static List<Manager> managersDb = new List<Manager>();


       

        public Manager Get(string userEmail)
        {
            foreach (var item in managersDb)
            {
                if (item.userEmail == userEmail && item.isDeleted == false)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Manager> GetAll()
        {
            foreach (var item in managersDb)
            {
                System.Console.WriteLine(item.isDeleted);
                if (item.isDeleted == true)
                {
                    return null;
                }
            }
            
            return managersDb;
        }

        public Manager Register(string firstname, string lastname, string email, string password, string phonenumber, string Address, Gender gender)
        {
           var manager = Check(email);
           if (manager == false)
           {
            System.Console.WriteLine("manager exist");
            return null;
           }
           User user = new User(UserManager.userDb.Count+1,firstname,lastname,email,password,phonenumber,Address,gender,"Manager",false);
           UserManager.userDb.Add(user);
            
            Manager managers = new Manager(ManagerManager.managersDb.Count+1,email,false);
            ManagerManager.managersDb.Add(managers);
            return managers;
        }
        private bool Check(string email)
        {
            foreach (var item in managersDb)
            {
                if (item.userEmail == email)
                {
                   return false; 
                }
            }
            return true;
        }
    }
}