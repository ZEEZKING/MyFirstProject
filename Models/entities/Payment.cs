using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Models.entities
{
    public class Payment : BaseEntity
    {
        public string HotelAccountNumber;
        public string CustomerAccountNumber;
        public double Amount;
        public string ReferenceNo;

        public Payment(int id,string hotelAccountNumber, string customerAccountNumber, double amount,string referenceno,bool isDeleted) : base(id,isDeleted)
        {
            HotelAccountNumber = hotelAccountNumber;
            CustomerAccountNumber = customerAccountNumber;
            Amount = amount;
            ReferenceNo = referenceno;
        }
    }
}