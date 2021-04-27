using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository.Abstract
{
    public interface IAccountsRepository
    {
        IEnumerable<Account> GetAccounts();

        Account GetAccountByName(string name);

        bool IsAccountInSystem(string accountName);

        void CreateAccount(Account entity);

        void UpdateAccount(Account entity);
    }
}
