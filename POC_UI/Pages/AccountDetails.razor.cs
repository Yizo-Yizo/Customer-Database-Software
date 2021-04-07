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
    public class AccountDetailsBase : ComponentBase
    {
        [Inject]
        public IAccountDataService AccountDataService { get; set; }

        [Inject]
        public IContactDataService ContactDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int AccountId { get; set; }

        [Parameter]
        public int Count { get; set; }

        public Account Account { get; set; } = new Account();

        public List<Contact> Contacts { get; set; }
        public List<Account> Accounts { get; set; }
        public IEnumerable<Contact> AssociatedContacts { get; set; }

        public string Filter { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Account = await AccountDataService.GetAccountById(AccountId);
            Accounts = (await AccountDataService.GetAllAccounts()).ToList();
            Contacts = (await ContactDataService.GetAllContacts()).ToList();

            

            AssociatedContacts = (from contact
                                   in Contacts
                                   where contact.AccountId == AccountId
                                   select contact);
            Count = AssociatedContacts.Count();
        }



        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("AccountsOverview");
        }

        protected void NavigateToPaymentProfile()
        {
            NavigationManager.NavigateTo($"/Payments/{AccountId}");

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

            return false;
        }
    }
}
