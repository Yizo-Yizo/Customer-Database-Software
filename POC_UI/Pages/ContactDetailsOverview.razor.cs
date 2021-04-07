using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Models;
using Proof_Of_Concept.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Proof_Of_Concept.Pages
{
    public class ContactDetailsOverviewBase : ComponentBase
    {
        [Inject]
        public IContactDataService IContactDataService { get; set; }

        public Contact Contact { get; set; } = new Contact();

        public List<Contact> Contacts { get; set; }

        public List<Contact> AssociatedContacts { get; set; }

        public string Filter { get; set; }
        public string message { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Contacts = (await IContactDataService.GetAllContacts()).ToList();
        }

        public bool IsVisible(Contact contact)
        {
            if (string.IsNullOrEmpty(Filter))
                return true;

            if (contact.ContactPerson == null)
                contact.ContactPerson = "N/A";
            else
                if (contact.ContactPerson.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (contact.Address == null)
                contact.Address = "N/A";
            else
                if (contact.Address.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;
            if (contact.Email == null)
                contact.Email = "N/A";
            else
                if (contact.Email.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (contact.Phone == null)
                contact.Phone = "N/A";
            else
                if (contact.Phone.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (contact.City == null)
                contact.City = "N/A";
            else
                if (contact.City.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (contact.Id.ToString().StartsWith(Filter))
                return true;

            return false;
        }
    }
}