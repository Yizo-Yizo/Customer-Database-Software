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
    public class AccountOverviewBase : ComponentBase
    {

        [Inject]
        public IAccountDataService AccountDataService { get; set; }

        [Inject]
        public IContactDataService ContactDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Count { get; set; }

        public string Filter { get; set; }

        public StatsModel StatsModel { get; set; } = new StatsModel();
        public Account Account { get; set; } = new Account();

        public List<Account> Accounts { get; set; }
        public List<Contact> Contacts { get; set; }

        public List<int> Numbers = new List<int>();
        public List<int> ListOfIDs = new List<int>();
        public List<string> ListOfNames = new List<string>();
        public List<string> ListOfEmails = new List<string>();
        public List<string> ListOfPhones = new List<string>();
        public List<string> ListOfAssociates = new List<string>();

        public List<int> NumberS = new List<int>();
        public List<int> ListOfIDS = new List<int>();
        public List<string> ListOfNameS = new List<string>();
        public List<string> ListOfEmailS = new List<string>();
        public List<string> ListOfPhoneS = new List<string>();

        public int i { get; set; }

        public List<Contact> AssociatedContacts { get; set; }

        protected override async Task OnInitializedAsync()
        {

            Accounts = (await AccountDataService.GetAllAccounts()).ToList();
            Contacts = (await ContactDataService.GetAllContacts()).ToList();

            Stats();
            ListOfAccounts();
            Associates();
        }

        private List<int> Stats()
        {
            foreach (var Account in Accounts)
            {
                AssociatedContacts = (from contact
                                       in Contacts
                                       where contact.AccountId == Account.Id
                                       select contact).ToList();
                Count = AssociatedContacts.Count();

                Numbers.Add(Count);
            }

            return Numbers;

        }

        private List<Contact> Associates()
        {
            foreach (var Account in Accounts)
            {
                AssociatedContacts = (from contact
                                      in Contacts
                                      where contact.AccountId == Account.Id
                                      select contact).ToList();

                foreach (var Associate in AssociatedContacts)
                {
                    ListOfIDS.Add(Associate.Id);
                    ListOfNameS.Add(Associate.ContactPerson);
                    ListOfEmailS.Add(Associate.Email);
                    ListOfPhoneS.Add(Associate.Phone);
                }

            }

            return AssociatedContacts;

        }

        public void ListOfAccounts()
        {
            foreach (var Account in Accounts)
            {
                ListOfIDs.Add(Account.Id);
                ListOfNames.Add(Account.AccountName);
                ListOfEmails.Add(Account.Email);
                ListOfPhones.Add(Account.Phone);
            }
        }

        // Filter 
        public bool Isvisible(int ID, string AccountName, string AccountEmail, string AccountPhone, int Number, 
            int ContactId, string ContactName, string ContactEmail, string ContactPhone)
        {
            if (string.IsNullOrEmpty(Filter))
                return true;
            
            if (Number.ToString().Contains(Filter, StringComparison.OrdinalIgnoreCase))
                return true;

            if (AccountName == null)
                AccountName = "N/A";
            else
                if (AccountName.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                return true;

            if (AccountEmail == null)
                AccountEmail = "N/A";
            else
                if (AccountEmail.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (AccountPhone == null)
                AccountPhone = "N/A";
            else
                if (AccountPhone.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            
            if (ID.ToString().StartsWith(Filter))
                return true;

            if (ContactName == null)
                ContactName = "N/A";
            else
                if (ContactName.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (ContactEmail == null)
                ContactEmail = "N/A";
            else
                if (ContactEmail.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (ContactPhone == null)
                ContactPhone = "N/A";
            else
                if (ContactPhone.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (ContactId.ToString().StartsWith(Filter))
                return true;

            return false;
        }

    }
}
