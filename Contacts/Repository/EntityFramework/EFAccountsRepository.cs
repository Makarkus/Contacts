using Contacts.Models;
using Contacts.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository.EntityFramework
{
    public class EFAccountsRepository : IAccountsRepository
    {
        private readonly ContactsDBContext contactsDBContext;

        public EFAccountsRepository(ContactsDBContext context)
        {
            this.contactsDBContext = context;
        }

        public IEnumerable<Account> GetAccounts()
        {
            try
            {
                return contactsDBContext.Accounts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Account GetAccountByName(string name)
        {
            try
            {
                return contactsDBContext.Accounts.FirstOrDefault(x => x.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsAccountInSystem(string accountName)
        {
            try
            {
                return contactsDBContext.Accounts.Contains(new Account { Name=accountName}); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void CreateAccount(Account entity)
        {
           this.contactsDBContext.Entry(entity).State = EntityState.Added;
                 
            this.contactsDBContext.SaveChangesAsync();
        }

        public async void UpdateAccount(Account entity)
        {
            this.contactsDBContext.Entry(entity).State = EntityState.Modified;
            this.contactsDBContext.SaveChangesAsync();
        }
    }
}
