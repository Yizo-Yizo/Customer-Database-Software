using Proof_Of_Concept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Interfaces
{
    public interface IContactDataService
    {
        Task AddContact(Contact newContact);
        Task DeleteContact(int contactId);
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int contactId);
        Task UpdateContact(Contact contact, int id);
    }
}
