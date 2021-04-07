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
    public class PaymentProfileDataService : IPaymentProfileDataService
    {
        private HttpClient _client;
        //private HttpRequestMessage requestMessage;

        public PaymentProfileDataService(HttpClient client)
        {
            _client = client;
        }

        public async Task AddPaymentProfile(PaymentProfile newPaymentProfile)
        {
            await _client.PostJsonAsync("/api/PaymentProfiles", newPaymentProfile);
        }

        public async Task UpdatePaymentProfile(PaymentProfile updatedPaymentProfile, int Id)
        {
            await _client.PutJsonAsync($"api/PaymentProfiles/{Id}", updatedPaymentProfile);
        }

        public async Task<PaymentProfile> GetSingle(int Id)
        {
            return await _client.GetJsonAsync<PaymentProfile>($"/api/PaymentProfiles/{Id}");
        }

        public async Task<IEnumerable<PaymentProfile>> GetAllPaymentProfiles()
        {
            return await _client.GetJsonAsync<PaymentProfile[]>("api/PaymentProfiles");
        }

        public async Task DeletePaymentProfile(int Id)
        {
            await _client.DeleteAsync($"api/PaymentProfiles/{Id}");
        }

        

     
    }
}
