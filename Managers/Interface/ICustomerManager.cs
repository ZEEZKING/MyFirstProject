
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Interface
{
    public interface ICustomerManager
    {
      Customer Register(string firstname, string lastName, string email, string password, string phonenumber, string Address, Gender gender);
      Customer Get(string UserEmail);
      Customer FundWallet(int customerId, double amount);
      Customer CheckWallet(string email);
      Customer Get(int customerId);          
      List<Customer> GetAll();
     
    }
}