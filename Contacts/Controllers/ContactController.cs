using Contacts.Models;
using Contacts.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {

        private readonly IAccountsRepository accountsRepository;
        private readonly IContactsRepository contactsRepository;

        public ContactController(IAccountsRepository accountsRepository, IContactsRepository contactsRepository)
        {
            this.accountsRepository = accountsRepository;
            this.contactsRepository = contactsRepository;

        }

        [HttpPost]
        public IActionResult Create([FromBody] DataFromPage data)
        {
            Contact newContact = new Contact
            {
                FirstName = data.contactFirstName,
                LastName = data.contactLastName,
                Email = data.contactEmail
            };
            return Ok();
        }
    }
}
