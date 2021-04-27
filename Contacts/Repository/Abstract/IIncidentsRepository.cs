using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Repository.Abstract
{
    public interface IIncidentsRepository
    {
        IEnumerable<Incident> GetIncidents();

        void CreateIncident(Incident entity);
    }
}
