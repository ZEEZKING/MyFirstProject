using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Managers.Interface;
using Hotel_App.Models.entities;

namespace Hotel_App.Managers.Implementation
{
    public class AccountManager : IAccountManager
    {
        public static List<Account> accountDb = new List<Account>()
        {
            new Account(1,"Adekoya" ,"0123456789",0,false)
        };

        public Account Create(string accountName, string accountNumber)
        {
            var accountGet = Get(accountNumber);
            if (accountGet != null)
            {
                System.Console.WriteLine("Account already exist");
                return null;
            }
            if (accountNumber.Length == 10)
            {
                Account account = new Account(AccountManager.accountDb.Count + 1, accountName, accountNumber,0,false);
                AccountManager.accountDb.Add(account);
                return account;
            }
            return null;
        }

        public bool Delete(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Account Get(string accountNumber)
        {
            foreach (var account in accountDb)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        public Account Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAll()
        {
            return accountDb;
        }
    

}
}