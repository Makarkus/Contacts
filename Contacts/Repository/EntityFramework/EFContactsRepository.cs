using Contacts.Models;
using Contacts.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository.EntityFramework
{
    public class EFContactsRepository:IContactsRepository
    {
        private readonly ContactsDBContext contactsDBContext;

        public EFContactsRepository(ContactsDBContext context)
        {
            this.contactsDBContext = context;
        }

        public IEnumerable<Contact> GetContacts()
        {
            try
            {
                return contactsDBContext.Contacts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Contact GetContactByEmail(string email)
        {
            try
            {
                return contactsDBContext.Contacts.FirstOrDefault(x=>x.Email==email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsContactInSystem(string email)
        {
            try
            {
                return contactsDBContext.Contacts.Contains(new Contact { Email=email });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void CreateContact(Contact entity)
        {
            this.contactsDBContext.Entry(entity).State = EntityState.Added;
            this.contactsDBContext.SaveChangesAsync();
        }

        public async void UpdateContact(Contact entity)
        {
           
           this.contactsDBContext.Entry(entity).State = EntityState.Modified;
           this.contactsDBContext.SaveChangesAsync();
        }
    }
}
