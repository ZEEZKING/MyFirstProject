using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Managers.Interface;
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        public static List<Customer> customerDb = new List<Customer>();
        

        public Customer FundWallet(int customerId, double amount)
        {
            var customerGet = Get(customerId);
            if (customerGet == null)
            {
                Console.WriteLine("Customer not found");
            }
            customerGet.Wallet += amount;
            System.Console.WriteLine("Wallet has been sucessfully fund");
            return customerGet;
        }

        public Customer Get(string UserEmail)
        {
            foreach (var item in customerDb)
            {
                if (item.UserEmail == UserEmail)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return customerDb;
        }

        public Customer Register(string firstname, string lastName, string email, string password, string phonenumber, string Address, Gender gender)
        {
            var customerExist = Exist(email);
            if (customerExist == false)
            {
                System.Console.WriteLine("customer Already Exist");
                return null;
            }
            
            User user = new User(UserManager.userDb.Count + 1, firstname, lastName, email, password, phonenumber, Address, gender, "Customer",false);
            // var userManager = new UserManager().Add(user);
            UserManager.userDb.Add(user);
        

            Customer customer = new Customer(CustomerManager.customerDb.Count + 1, user.Email,0,false);
            customerDb.Add(customer);

            // Account account = new Account(AccountManager.accountDb.Count + 1,$"{firstname} {lastName}");
            // AccountManager.accountDb.Add(account);
            return customer;
           
        }
        private bool Exist(string email)
        {
            foreach (var customer in customerDb)
            {
                if (customer.UserEmail == email)
                {
                    return false;
                }
            }
            return true;
        }
        public Customer Get(int customerId)
        {
            foreach (var customer in customerDb)
            {
                if (customer.Id == customerId)
                {
                    return customer;
                }
            }
            return null;
        }
        public Customer CheckWallet(string email)
        {
            foreach (var item in CustomerManager.customerDb)
            {
                if (item.UserEmail == email)
                {
                  return item ; 
                }
            
            }
            return null;
        }

    }

}