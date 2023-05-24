using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Managers.Interface;
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Implementation
{
    public class PaymentManager : IPaymentManager
    {
        IRoomManager roomManager = new RoomManager();
        ICustomerManager customerManager = new CustomerManager();
        IAccountManager accountManager = new AccountManager();
        IBookingManager bookingManager = new BookingManager();
        public static List<Payment> paymentDb = new List<Payment>();


        public List<Payment> GetAll()
        {
            return paymentDb;
        }

        public Payment MakePayment(string hotelAccountNumber, string email, double amount, RoomType roomType,int days)
        {
            Payment payment = null;
            var referenceno = GenerateRefNo();
            var roomp = roomManager.GetRoomType(roomType);
            var customeracct = customerManager.Get(email);
            if (customeracct == null)
            {
                System.Console.WriteLine("account not found");
            }
            var hotelacct = accountManager.Get(hotelAccountNumber);
            if (hotelacct == null)
            {
                System.Console.WriteLine(" account not found");
            }
            if (roomp == null)
            {
                System.Console.WriteLine("Room not found");
            }
            else
            {
                if (amount >= roomp.Price*days)
                {
                    customeracct.Wallet -= roomp.Price*days;
                    hotelacct.AccountBalance +=roomp.Price*days;
                    payment = new Payment(PaymentManager.paymentDb.Count + 1, hotelacct.AccountNumber, customeracct.UserEmail, amount, referenceno,false);
                    paymentDb.Add(payment);
                     return payment; 
                }
           }
            return null;
           
        }
        private string GenerateRefNo()
        {
            Random rand = new Random();
            return "Ref/No/Pay" + rand.Next(100, 999);
        }
        

    }
}