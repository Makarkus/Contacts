using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository.Abstract
{
    public interface IContactsRepository
    {
        IEnumerable<Contact> GetContacts();

        Contact GetContactByEmail(string email);

        bool IsContactInSystem(string email);

        void CreateContact(Contact entity);

        void UpdateContact(Contact entity);
    }
}
