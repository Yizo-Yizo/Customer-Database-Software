using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Proof_Of_Concept.Services
{
    public class AccountFilter
    {
        [Inject]
        public IAccountDataService AccountDataService { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
