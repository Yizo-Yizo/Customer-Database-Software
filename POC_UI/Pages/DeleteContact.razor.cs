using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Pages
{
    public class DeleteContactBase : ComponentBase
    {
        [Inject]
        public IContactDataService ContactDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<Contact> Contacts { get; set; }

        public Contact Contact { get; set; } = new Contact();

        [Parameter]
        public int ContactId { get; set; }

        public string Filter { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Contact = await ContactDataService.GetContactById(ContactId);
            if (ContactId != 0)
            {
                await ContactDataService.DeleteContact(ContactId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            await ContactDataService.DeleteContact(ContactId);

            NavigationManager.NavigateTo("/Contacts");
        }

        protected void NavigateToContactsOverview()
        {
            NavigationManager.NavigateTo("/Contacts");
        }
    }
}
