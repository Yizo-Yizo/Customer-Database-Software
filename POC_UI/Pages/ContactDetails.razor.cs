using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Models;
using Proof_Of_Concept.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Pages
{
    public class ContactDetailsBase : ComponentBase
    {
        [Inject]
        public IAccountDataService AccountDataService { get; set; }

        [Inject]
        public IContactDataService ContactDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int ContactId { get; set; }

        public List<Contact> Contacts { get; set; }
        public List<Account> Accounts { get; set; }
        public IEnumerable<Contact> AssociatedContacts { get; set; }

        public string Filter { get; set; }

        public Contact Contact { get; set; } = new Contact();

        protected override async Task OnInitializedAsync()
        {
            
            Contact = await ContactDataService.GetContactById(ContactId);
            //Accounts = (await AccountDataService.GetAllAccounts()).ToList();
            Contacts = (await ContactDataService.GetAllContacts()).ToList();

            AssociatedContacts = (from contact
                                   in Contacts
                                  where contact.AccountId == ContactId
                                  select contact);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/Contacts");
        }

        public bool Isvisible(Contact associatedContact)
        {
            if (string.IsNullOrEmpty(Filter))
                return true;

            if (associatedContact.ContactPerson == null)
                associatedContact.ContactPerson = "N/A";
            else
                if (associatedContact.ContactPerson.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (associatedContact.Address == null)
                associatedContact.Address = "N/A";
            else
                if (associatedContact.Address.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (associatedContact.Email == null)
                associatedContact.Email = "N/A";
            else
                if (associatedContact.Email.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (associatedContact.Phone == null)
                associatedContact.Phone = "N/A";
            else
                if (associatedContact.Phone.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;
            if (associatedContact.City == null)
                associatedContact.City = "N/A";
            else
                if (associatedContact.City.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (associatedContact.Id.ToString().StartsWith(Filter))
                return true;

            return false;
        }
    }
}
