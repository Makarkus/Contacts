using Contacts.Models;
using Contacts.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Contacts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountsRepository accountsRepository;
        private readonly IContactsRepository contactsRepository;

        public AccountController(IAccountsRepository accountsRepository, IContactsRepository contactsRepository)
        {
            this.accountsRepository = accountsRepository;
            this.contactsRepository = contactsRepository;
            
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return accountsRepository.GetAccounts();
        }

        [HttpGet("{id}")]
        public Account Get(string name)
        {
            return accountsRepository.GetAccounts().FirstOrDefault(x=>x.Name==name);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DataFromPage data)
        {
            if (contactsRepository.IsContactInSystem(data.contactEmail) == false)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            Contact accountContact= contactsRepository.GetContactByEmail(data.contactEmail);
            Account newAccount = new Account { Name=data.accountName,ContactId=accountContact.Id};
            accountsRepository.CreateAccount(newAccount);
            return Ok();

        }

    }
}
