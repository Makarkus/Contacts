using Contacts.Models;
using Contacts.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository.EntityFramework
{
    public class EFIncedentsRepository : IIncidentsRepository
    {
        private readonly ContactsDBContext contactsDBContext;

        public EFIncedentsRepository(ContactsDBContext context)
        {
            this.contactsDBContext = context;
        }

        public IEnumerable<Incident> GetIncidents()
        {
           try
           {
                return contactsDBContext.Incidents;
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
        }

        public async void CreateIncident(Incident entity)
        {
          this.contactsDBContext.Entry(entity).State = EntityState.Added;
          this.contactsDBContext.SaveChangesAsync();
        }
    }
}
