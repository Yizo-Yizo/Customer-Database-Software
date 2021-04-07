using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Pages
{
    public class DeleteAccountBase : ComponentBase
    {
        [Inject]
        public IAccountDataService AccountDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<Account> Accounts { get; set; }

        public Account Account { get; set; } = new Account();

        [Parameter]
        public int AccountId { get; set; }

        public string Filter { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Account = await AccountDataService.GetAccountById(AccountId);
            if (AccountId != 0)
            {
               await AccountDataService.DeleteAccount(AccountId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            await AccountDataService.DeleteAccount(AccountId);

            NavigationManager.NavigateTo("AccountsOverview");
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("AccountsOverview");
        }

    }
}
