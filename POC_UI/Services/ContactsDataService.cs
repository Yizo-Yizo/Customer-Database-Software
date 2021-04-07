using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Models;
using Proof_Of_Concept.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Services
{
    public class ContactsDataService : IContactDataService
    {
        public Contact[] Contacts { get; set; }
        public Account[] Accounts { get; set; }

        private HttpClient _client;

        public ContactsDataService(HttpClient client)
        {
            _client = client;
        }

        public async Task AddContact(Contact newContact)
        {
            await _client.PostJsonAsync("/api/Contacts", newContact);
        }

        public async Task UpdateContact(Contact updatedContact, int Id)
        {
            await _client.PutJsonAsync($"api/Contacts/{Id}", updatedContact);
        }

        public async Task<Contact> GetContactById(int contactId)
        {
            return await _client.GetJsonAsync<Contact>($"api/Contacts/{contactId}");
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _client.GetJsonAsync<Contact[]>("api/Contacts");

        }

        public async Task DeleteContact(int contactId)
        {
            await _client.DeleteAsync($"api/Contacts/{contactId}");
        }
    }
}
