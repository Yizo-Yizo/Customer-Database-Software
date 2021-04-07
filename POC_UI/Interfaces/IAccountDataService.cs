using Proof_Of_Concept.Models;
using Proof_Of_Concept.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Interfaces
{
    public interface IAccountDataService
    {
        Task AddAccount(Account newAccount);
        Task DeleteAccount(int accountId);
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountById(int accountId);
        Task UpdateAccount(Account account, int id);
        Task<StatsModel> GetStats(int id);
    }
}
