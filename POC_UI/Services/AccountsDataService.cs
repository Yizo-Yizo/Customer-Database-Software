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
        //private HttpRequestMessage requestMessage;

        public AccountsDataService(HttpClient client)
        {
            _client = client;
        }
        
        public async Task AddAccount(Account newAccount)
        {
            /*var dictionary = newAccount.GetType().GetProperties()
                .ToDictionary(p => p.Name, p => p.GetValue(newAccount).ToString());

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri("https://localhost:44377/api/Accounts"),
                Content = new FormUrlEncodedContent(dictionary)
            };

            requestMessage.Headers.Add("x-custom", "secretCode");

            await _client.SendAsync(requestMessage);*/
            await _client.PostJsonAsync("/api/Accounts", newAccount);
        }

        public async Task UpdateAccount(Account updatedAccount, int Id)
        {
            /*var dictionary = updatedAccount.GetType().GetProperties()
                .ToDictionary(p => p.Name, p => p.GetValue(updatedAccount).ToString());

            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri("https://localhost:44377/api/Accounts"),
                Content = new FormUrlEncodedContent(dictionary)
            };

            requestMessage.Headers.Add("x-custom", "secretCode");

            await _client.SendAsync(requestMessage);*/
            await _client.PutJsonAsync($"api/Accounts/{Id}", updatedAccount);
        }

        public async Task<Account> GetAccountById(int accountId)
        {
            return await _client.GetJsonAsync<Account>($"api/Accounts/{accountId}");
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _client.GetJsonAsync<Account[]>("api/Accounts");
            /*return (IEnumerable<Account>)await JsonSerializer.DeserializeAsync<List<Account[]>>
                (await _client.GetStreamAsync($"api/Accounts"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });*/
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
