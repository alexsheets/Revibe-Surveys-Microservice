using System.Collections.Generic;
using AutoMapper;
using Surveys.Data;
using Surveys.Dtos;
using Surveys.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;


namespace Surveys.Controllers
{
    [Route("api/contacts/")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepo _repository;
        private readonly IMapper _mapper;

        public ContactsController(IContactRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/contacts/
        [HttpGet]
        public ActionResult <IEnumerable<ContactReadDto>> GetAllContacts()
        {
            var contactItems = _repository.GetAllContacts();
            return Ok(_mapper.Map<IEnumerable<ContactReadDto>>(contactItems));
        }
        
        // GET api/contacts/{id}
        [HttpGet("{id}", Name="GetContactById")]
        public ActionResult <ContactReadDto> GetContactById(int id)
        {
            var contactItem = _repository.GetContactById(id);
            if(contactItem != null)
            {
                return Ok(_mapper.Map<ContactReadDto>(contactItem));
            }
            return NotFound();
        }

        // POST api/contacts/
        [HttpPost]
        public ActionResult <ContactReadDto> CreateContact(ContactCreateDto contactCreateDto)
        {
            // validation check ??
            // map contact create dto and contact object
            var contactModel = _mapper.Map<Contact>(contactCreateDto);
            // create a new contact in the repository
            _repository.CreateContact(contactModel);
            // save new contact
            _repository.SaveChanges();

            var ContactReadDto = _mapper.Map<ContactReadDto>(contactModel);
            // response
            return CreatedAtRoute(nameof(GetContactById), new {Id = ContactReadDto.Id}, ContactReadDto);
        }
        
        // POST api/contacts/{id}
        [HttpPost("{id}")]
        public ActionResult <ContactReadDto> SendEmail(int id)
        {
            var contact = _repository.GetContactById(id);
            if(contact != null)
            {
                var mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress("Revibe Support", "no-reply@revibe.tech"));
                mailMessage.Subject = "New contact submission: " + contact.Subject;
                mailMessage.Body = new TextPart("html")
                {
                    Text = contact.Message
                };

                using (var smtpClient = new SmtpClient())
                    {
                    smtpClient.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                    smtpClient.Authenticate("srevibe@gmail.com", "th3B3stp@$$");
                    smtpClient.Send(mailMessage);
                    smtpClient.Disconnect(true);
                    }
            }
            return NotFound();
        }
    }
}