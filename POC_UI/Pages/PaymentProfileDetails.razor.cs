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
    public class PaymentProfileBase : ComponentBase
    {
        [Inject]
        public IPaymentProfileDataService PaymentProfileDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int PaymentProfileId { get; set; }

        public PaymentProfile PaymentProfile { get; set; } = new PaymentProfile();

        protected override async Task OnInitializedAsync()
        {
            PaymentProfile = await PaymentProfileDataService.GetSingle(PaymentProfileId);
        }
    }
}
