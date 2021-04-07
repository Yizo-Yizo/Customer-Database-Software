using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proof_Of_Concept.Shared
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string PrimaryContact { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }
    }
}
