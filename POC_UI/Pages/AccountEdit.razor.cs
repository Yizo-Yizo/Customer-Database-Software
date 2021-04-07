using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Pages
{
    public class AccountEditBase : ComponentBase
    {
        [Inject]
        public IAccountDataService AccountDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Account Account { get; set; } = new Account();

        [Parameter]
        public int AccountId { get; set; }
        public string Message { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (AccountId != 0)
            {
                Account = await AccountDataService.GetAccountById(AccountId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Account.Id == 0) // New 
            {
                await AccountDataService.AddAccount(Account);
            }
            else
            {
                await AccountDataService.UpdateAccount(Account, Account.Id);
            }

            NavigationManager.NavigateTo("/AccountsOverview");
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/AccountsOverview");
        }
    }
}
