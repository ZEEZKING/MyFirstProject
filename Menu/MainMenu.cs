using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Managers.Implementation;
using Hotel_App.Managers.Interface;
using Hotel_App.Models.enums;

namespace Hotel_App.Menu
{
    public class MainMenu
    {
        ICustomerManager customerManager = new CustomerManager();
        IUserManager userManager = new UserManager();
        superAdminMenu superAdmin = new superAdminMenu();
        CustomerMenu customerMenu = new CustomerMenu();
        ManagerMenu managerMenu = new ManagerMenu();
        public void Main()
        {
            System.Console.WriteLine("Welcome to ZEEZKING Hotellier\nEnter 1 to Register \nEnter 2 to Login");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                Register();
            }
            else if (input == 2)
            {
                Login();
            }
            else
            {
                System.Console.WriteLine("Invalid input");
                Main();
            }
        }
        // string firstname, string lastName, string email, string password, string phonenumber, string Address, Gender gender, string role, string accountNumber, int customerpin, string accountName
        public void Register()
        {
           Console.Write("Enter Your firstName : ");
           string fname = Console.ReadLine();
           Console.Write("Enter Your LastName : ");
           string lname = Console.ReadLine();
           Console.Write("Enter Your email  : ");
           string email = Console.ReadLine();
           Console.Write("Enter your password : ");
           string password = Console.ReadLine();
           Console.Write("Enter Your phonenumber : ");
           string phoneNumber = Console.ReadLine();
           Console.Write("Enter your address :");
           string address = Console.ReadLine();
           Console.Write("Enter 1 for male and 2 for female : ");
           int  gender = int.Parse(Console.ReadLine());
           if (gender == 1 || gender == 2)
           {
            
           }
           else
           {
            System.Console.WriteLine("Invalid input");
            Main();
           }
           
          

           var register = customerManager.Register(fname,lname,email,password,phoneNumber,address,(Gender) gender);
           if (register == null)
           {
            System.Console.WriteLine("Account not found");
           } 
           else
           {
            System.Console.WriteLine($"Congratulation {fname} {lname} you have successfully created an account");
           }
           Main();

        }
        public void Login()
        {
            Console.Write("Enter your email :");
            string email = Console.ReadLine();
            Console.Write("Enter your password : ");
            string password = Console.ReadLine();
            
            var login = userManager.Login(email,password);
            if (login == null)
            {
                System.Console.WriteLine("Invalid credentials");
                Login();
            }
            else
            {
                System.Console.WriteLine("Login sucessful");
                if(login.Role == "SuperAdmin")
                {
                    superAdmin.SuperMain();
                }
                else if(login.Role == "Manager")
                {
                    managerMenu.ManagerMainMenu();
                }
                else if(login.Role == "Customer")
                {
                    customerMenu.CustomerMain();
                }
            }
        }
    }
}