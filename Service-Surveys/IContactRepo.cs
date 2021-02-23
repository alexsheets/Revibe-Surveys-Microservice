using System.Collections.Generic;
using Surveys.Models;

namespace Surveys.Data
{
    public interface IContactRepo
    {
        bool SaveChanges();
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void CreateContact(Contact contact);
    }
}