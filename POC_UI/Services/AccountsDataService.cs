using Microsoft.AspNetCore.Components;
using Proof_Of_Concept.Interfaces;
using Proof_Of_Concept.Models;
using Proof_Of_Concept.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Services
{
    public class AccountsDataService : IAccountDataService
    {
        private HttpClient _client;

        public AccountsDataService(HttpClient client)
        {
            _client = client;
        }
        
        public async Task AddAccount(Account newAccount)
        {
            await _client.PostJsonAsync("/api/Accounts", newAccount);
        }

        public async Task UpdateAccount(Account updatedAccount, int Id)
        {
            await _client.PutJsonAsync($"api/Accounts/{Id}", updatedAccount);
        }

        public async Task<Account> GetAccountById(int accountId)
        {
            return await _client.GetJsonAsync<Account>($"api/Accounts/{accountId}");
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _client.GetJsonAsync<Account[]>("api/Accounts");
        }

        public async Task DeleteAccount(int accountId)
        {
            await _client.DeleteAsync($"api/Accounts/{accountId}");
        }

        public async Task<StatsModel> GetStats(int accountId)
        {
            return await _client.GetJsonAsync<StatsModel>($"api/Accounts/CountContacts/{accountId}");

        }
    }
}
