using Hotel_App.Managers.Interface;
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Implementation
{
    public class UserManager : IUserManager
    {
        // private string path = @"C:\Users\Harzeez\Desktop\Hotel App\File\user.txt";
        public static List<User> userDb = new List<User>()
        {
            new User(1, "AbdulAzeez", "Adekoya", "ade@email.com", "123","07051459639","Lagos",Gender.male,"SuperAdmin",false)
        };


    

        public User Get(string email)
        {
            foreach (var user in userDb)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        // public User Add(User user)
        // {
        //     using (var streamWriter = new StreamWriter(path))
        //     {
        //         streamWriter.WriteLine(user.ToString());
        //     }
        //     userDb.Add(user);
        //     return user;
        // }

        public List<User> GetAll()
        {
            return userDb;
        }

        public User Login(string email, string password)
        {
            foreach (var user in userDb)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        // public void LoadDataFileFrom()
        // {
        //     var data = File.ReadAllLines(path);
        //     foreach (var item in data)
        //     {
        //         userDb.Add(ConvertToUserobject(item));
        //     }
        // }
        // private User ConvertToUserobject(string data)
        // {
        //     var newData = data.Split(' ');
        //     Enum.TryParse(newData[7], out Gender val);
        //     return new User(int.Parse(newData[0]), newData[1], newData[2], newData[3], newData[4], newData[5], newData[6], val, newData[8]);
        // }
    }
}