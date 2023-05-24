using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Interface
{
    public interface IAccountManager
    {
         Account Create(string accountName, string accountNumber);
         Account Get(string accountNumber);
         Account Get(int id);
         List<Account> GetAll();
    
         bool Delete(string accountNumber);
    }
}