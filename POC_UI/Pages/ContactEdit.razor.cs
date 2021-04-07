using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Pages
{
    public class ContactEditBase : ComponentBase
    {
        [Inject]
        public IContactDataService ContactDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Contact Contact { get; set; } = new Contact();

        [Parameter]
        public int ContactId { get; set; }
        public string Message { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ContactId != 0)
            {
                Contact = await ContactDataService.GetContactById(ContactId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Contact.Id == 0) // New 
            {
                await ContactDataService.AddContact(Contact);
            }
            else
            {
                await ContactDataService.UpdateContact(Contact, Contact.Id);
            }

            NavigationManager.NavigateTo("/Contacts");
        }

        protected void NavigateToContactsOverview()
        {
            NavigationManager.NavigateTo("/Contacts");
        }
    }
}
