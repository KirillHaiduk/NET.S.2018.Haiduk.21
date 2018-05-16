using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class BankContext : DbContext
    {
        public BankContext() : base()
        {
        }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().HasKey(b => b.AccountNumberID);
            modelBuilder.Entity<Client>().HasKey(c => c.PassportID);
        }
    }
}
