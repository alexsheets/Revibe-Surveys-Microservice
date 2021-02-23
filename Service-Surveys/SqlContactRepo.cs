using System;
using System.Collections.Generic;
using System.Linq;
using Surveys.Models;

namespace Surveys.Data
{
    public class SqlContactRepo : IContactRepo
    {
        private readonly ContactContext _context;

        public SqlContactRepo(ContactContext context)
        {
            _context = context;
        }

        public void CreateContact(Contact contact)
        {
            if(contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            _context.Contacts.Add(contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _context.Contacts.ToList();
        }
        public Contact GetContactById(int id)
        {
            return _context.Contacts.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}