using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class Incident
    {
        [Key]
        public Guid Name { get; set; }

        public string Description { get; set; }

        public string AccountName { get; set; }
        public Account Account { get; set; }

    }
}
