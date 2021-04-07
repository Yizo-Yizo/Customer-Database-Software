using Proof_Of_Concept.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Proof_Of_Concept.Models;

namespace Proof_Of_Concept.Interfaces
{
    public interface IPaymentProfileDataService
    {
        Task AddPaymentProfile(PaymentProfile paymentprofile);
        Task<IEnumerable<PaymentProfile>> GetAllPaymentProfiles();
        Task<PaymentProfile> GetSingle(int Id);
        Task UpdatePaymentProfile(PaymentProfile PaymentProfile, int id);
        Task DeletePaymentProfile(int Id);
    }
}
