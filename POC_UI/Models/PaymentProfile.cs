using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Models
{
    public class PaymentProfile
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Owner { get; set; }
        public string Iban { get; set; } // International Bank Account Number
        public string Bic { get; set; } // Bank account code
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }
    }
}
