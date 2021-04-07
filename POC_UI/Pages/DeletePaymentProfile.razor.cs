using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Pages
{
    public class DeletePaymentProfileBase : ComponentBase
    {
        [Inject]
        public IPaymentProfileDataService PaymentProfileDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<PaymentProfile> PaymentProfiles { get; set; }

        public PaymentProfile PaymentProfile { get; set; } = new PaymentProfile();

        [Parameter]
        public int PaymentProfileId { get; set; }

        public string Message { get; set; }
        public string Filter { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PaymentProfile = await PaymentProfileDataService.GetSingle(PaymentProfileId);
            if (PaymentProfileId != 0)
            {
                await PaymentProfileDataService.DeletePaymentProfile(PaymentProfileId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            await PaymentProfileDataService.DeletePaymentProfile(PaymentProfileId);

            NavigationManager.NavigateTo("/PaymentProfileOverview");
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/PaymentProfileOverview");
        }
    }
}

