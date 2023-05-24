using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Interface
{
    public interface IPaymentManager
    {
         Payment MakePayment(string hotelAccountNumber, string email, double amount,RoomType roomType,int days);
         List<Payment> GetAll();
        
        
    }
}