using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class BankContext : DbContext
    {
        public BankContext() : base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BankContext, Migrations.Configuration>());
        }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<BankAccount>().HasKey(b => b.AccountNumberID);
            modelBuilder.Entity<Client>().HasKey(c => c.PassportID);

            modelBuilder.Entity<BankAccount>().Property(b => b.AccountNumber).HasColumnOrder(2).IsRequired();
            modelBuilder.Entity<BankAccount>().Property(b => b.IsClosed).HasColumnOrder(3).IsRequired();
        }
    }
}
