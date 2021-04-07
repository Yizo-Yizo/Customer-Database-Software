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
        /*protected async Task studentFilteringList(String Value, string columnName)
        {
            Accounts = (await AccountDataService.GetAllAccounts()).ToList(); ;

            if (Value.Trim().Length > 0)
            {
                switch (columnName)
                {
                    case "AccountName":
                        Accounts = (List<Account>)Accounts.Where(x => x.AccountName.Contains(Value));
                        break;

                    case "Email":
                        Accounts = (List<Account>)Accounts.Where(x => x.Email.Contains(Value));
                        break;
                    case "Phone":
                        Accounts = (List<Account>)Accounts.Where(x => x.Phone.Contains(Value));
                        break;
                    case "Address":
                        Accounts = (List<Account>)Accounts.Where(x => x.Address.Contains(Value));
                        break;
                    case "City":
                        Accounts = (List<Account>)Accounts.Where(x => x.City.Contains(Value));
                        break;
                    case "PrimaryContact":
                        Accounts = (List<Account>)Accounts.Where(x => x.PrimaryContact.Contains(Value));
                        break;
                    case "Status":
                        Accounts = (List<Account>)Accounts.Where(x => x.Status.Contains(Value));
                        break;
                    default:
                        Accounts = (await AccountDataService.GetAllAccounts()).ToList();
                        break;
                }
            }
            else
            {
                Accounts = (await AccountDataService.GetAllAccounts()).ToList();
            }
        }*/
    }
}
