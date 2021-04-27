using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class Account
    {
        [Key]
        public string Name { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public List<Incident> Incidents { get; set; }
    }
}
