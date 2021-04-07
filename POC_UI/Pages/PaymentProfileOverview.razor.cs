using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Pages
{
    public class PaymentProfileOverviewBase : ComponentBase 
    {
        [Inject]
        public IPaymentProfileDataService PaymentProfileDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int PaymentProfileId { get; set; }

        public PaymentProfile PaymentProfile { get; set; } = new PaymentProfile();

        public string Filter { get; set; }

        public List<PaymentProfile> PaymentProfiles { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PaymentProfiles = (await PaymentProfileDataService.GetAllPaymentProfiles()).ToList();
        }

        public bool IsVisible(PaymentProfile paymentProfile)
        {
            if (string.IsNullOrEmpty(Filter))
                return true;

            
            if (paymentProfile.Id.ToString().Contains(Filter, StringComparison.OrdinalIgnoreCase))
                return true;

            if (paymentProfile.Owner == null)
                paymentProfile.Owner = "N/A";
            else
                if (paymentProfile.Owner.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (paymentProfile.Iban == null)
                paymentProfile.Iban = "N/A";
            else
                if (paymentProfile.Iban.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            if (paymentProfile.Status == null)
                paymentProfile.Status = "N/A";
            else
                if (paymentProfile.Status.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                    return true;

            return false;

        }
    }
}
