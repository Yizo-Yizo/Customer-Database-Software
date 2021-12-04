using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POC_API.Models;


namespace POC_API.Data
{
    public class pocContext : DbContext
    {
        public pocContext(DbContextOptions<pocContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
