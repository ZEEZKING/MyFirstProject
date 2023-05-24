
using Hotel_App.Models.enums;

namespace Hotel_App.Models.entities
{
    public class User : BaseEntity
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public string PhoneNumber;
        public string address;
        public Gender Gender;
        public string Role;

        public User(int id, string firstname,string lastname, string email, string password, string phonenumber, string Address, Gender gender, string role,bool isDeleted) : base(id,isDeleted)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            PhoneNumber = phonenumber;
            address = Address;
            Gender = gender;
            Role = role;



        }
        // public override string ToString()
        // {
        //     return $"{Id} {FirstName} {LastName} {Email} {Password} {PhoneNumber} {address} {Gender} {Role}";
        // }
    }
}