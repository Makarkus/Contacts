using Contacts.Models;
using Contacts.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Contacts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentsRepository incidentsRepository;
        private readonly IAccountsRepository accountsRepository;
        private readonly IContactsRepository contactsRepository;

        public IncidentController(IIncidentsRepository incidentsRepository, IAccountsRepository accountsRepository, IContactsRepository contactsRepository)
        {
            this.incidentsRepository = incidentsRepository;
            this.accountsRepository = accountsRepository;
            this.contactsRepository = contactsRepository;

        }

        [HttpPost]
        public IActionResult Create([FromBody] DataFromPage data)
        {
      
            if (accountsRepository.IsAccountInSystem(data.accountName) == false)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            if (contactsRepository.IsContactInSystem(data.contactEmail))
            {
                Contact updatedContact = contactsRepository.GetContactByEmail(data.contactEmail);
                Account updatedAccount = accountsRepository.GetAccountByName(data.accountName);

                updatedContact.FirstName = data.contactFirstName;
                updatedContact.LastName = data.contactLastName;
                updatedContact.Email = data.contactEmail;
                updatedAccount.ContactId = updatedContact.Id;

                contactsRepository.UpdateContact(updatedContact);
                accountsRepository.UpdateAccount(updatedAccount);
            }
            else
            {
                Contact newContact = new Contact
                {
                    FirstName = data.contactFirstName,
                    LastName = data.contactLastName,
                    Email = data.contactEmail
                };
                Account updatedAccount = accountsRepository.GetAccountByName(data.accountName);
                updatedAccount.ContactId = newContact.Id;

                contactsRepository.CreateContact(newContact);
                accountsRepository.UpdateAccount(updatedAccount);
            }

            Incident newIncident = new Incident { Description = data.incidentDescription, AccountName = data.accountName };
            incidentsRepository.CreateIncident(newIncident);
            return Ok();

        }

    }
}
