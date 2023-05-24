using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Managers.Implementation;
using Hotel_App.Managers.Interface;
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Menu
{
    public class CustomerMenu
    {

        IRoomManager roomManager = new RoomManager();
        IPaymentManager paymentManager = new PaymentManager();
        ICustomerManager customerManager = new CustomerManager();
        IBookingManager bookingManager = new BookingManager();
        public void CustomerMain()
        {
            System.Console.WriteLine("Enter 1 to fund to your wallet\nEnter 2 to check your wallet\nEnter 3 to book room\nEnter 4 to logout");
            int opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                FundWallet();
                CustomerMain();

            }
            else if (opt == 2)
            {
                CheckWallet();
                CustomerMain();
            }
            else if (opt == 3)
            {
                BookingMenu bookingMenu = new BookingMenu();
                bookingMenu.Main();
                
                CustomerMain();
            }
            else if (opt == 4)
            {
                MainMenu MainMenu = new MainMenu();
                MainMenu.Main();
            }
            else
            {
                System.Console.WriteLine("please enter a valid input ");
                CustomerMain();
            }

        }

        public void MakePayment(Room room,int days)
        {
            System.Console.WriteLine("The price of PlantiniumRoom is 20000\nThe price of SilverRoom is 15000\nThe price of BronzeRoom is 10000");
            System.Console.WriteLine();

            Start:
            
            System.Console.WriteLine("The hotel account number is 0123456789");
            System.Console.WriteLine();
            System.Console.Write("Enter hotel account number : ");
            string hotelacct = Console.ReadLine();
            System.Console.Write("Enter your email : ");
            string email = Console.ReadLine();
            var customer = customerManager.Get(email);
            if (customer == null)
            {
                System.Console.WriteLine("Invalid details");
                goto Start;
            }
            System.Console.WriteLine($"The amount you are required to pay is : {room.Price * days}");
            System.Console.Write("Enter the amount you want to pay : ");
            double amt = double.Parse(Console.ReadLine());
            
            var roompay = paymentManager.MakePayment(hotelacct, customer.UserEmail, amt, room.RoomType,days);
            if (roompay == null)
            {
                System.Console.WriteLine("Transaction unsucessful");
                goto Start;
            }
            else
            {
                System.Console.WriteLine($"The transaction was sucessful {email} at {DateTime.Now} ");
            }

        }
        public void FundWallet()
        {
        
            System.Console.Write("Enter your email : ");
            string email = Console.ReadLine();
            var customer = customerManager.Get(email);
            if (customer == null)
            {
                System.Console.WriteLine("email not found");
                 CustomerMenu customerMenu = new CustomerMenu();
                customerMenu.CustomerMain();
                
            }
      
            System.Console.Write("Enter the amount : ");
            double amount = double.Parse(Console.ReadLine());

            if (amount >= 0)
            {
                // customer.Wallet += amount;

            }
            else
            {
                System.Console.WriteLine("Invalid Input");
                System.Console.WriteLine("InsufficientFund");
                
            }
            var fund = customerManager.FundWallet(customer.Id, amount);
            if (fund == null)
            {
                System.Console.WriteLine("Transaction unsucessful");
            }
            else
            {
                System.Console.WriteLine($"Transaction sucessful {email} at {DateTime.Now}");
            }
        }
        public void CheckWallet()
        {
            System.Console.Write("Enter your email : ");
            string email = Console.ReadLine();
            var customerWallet = customerManager.CheckWallet(email);
            if (customerWallet == null)
            {
                System.Console.WriteLine("Wallet not found");
            }
            else
            {
                System.Console.WriteLine($"Your wallet balance is {customerWallet.Wallet}");
            }
        }
    }
}