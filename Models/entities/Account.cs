using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App.Models.entities
{
    public class Account : BaseEntity
    {
        public string AccountName;
        public string AccountNumber;
        public double  AccountBalance;

        public Account( int id ,string accountName, string accountNumber, double accountBalance,bool isDeleted) : base(id,isDeleted)
        {
            AccountName = accountName;
            AccountNumber = accountNumber;
            AccountBalance = accountBalance;
        }
    }
}