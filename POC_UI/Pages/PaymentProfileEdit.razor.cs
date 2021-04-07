using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Pages
{
    public class PaymentProfileEditBase : ComponentBase
    {
        [Inject]
        public IPaymentProfileDataService PaymentProfileDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public PaymentProfile PaymentProfile { get; set; } = new PaymentProfile();

        [Parameter]
        public int PaymentProfileId { get; set; }
        public string Message { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (PaymentProfileId != 0)
            {
                PaymentProfile = await PaymentProfileDataService.GetSingle(PaymentProfileId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (PaymentProfile.Id == 0) // New 
            {
                await PaymentProfileDataService.AddPaymentProfile(PaymentProfile);
            }
            else
            {
                await PaymentProfileDataService.UpdatePaymentProfile(PaymentProfile, PaymentProfile.Id);
            }

            NavigationManager.NavigateTo($"Payments/{PaymentProfile.Id}");
        }

        protected void AccountDetails()
        {
            NavigationManager.NavigateTo($"AccountDetails/{PaymentProfile.Id}");
        }
    }
}
