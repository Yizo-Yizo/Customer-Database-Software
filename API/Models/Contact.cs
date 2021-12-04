using System;

namespace POC_API.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
