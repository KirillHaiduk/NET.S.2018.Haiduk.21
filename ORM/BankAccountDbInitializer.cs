using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class BankAccountDbInitializer : CreateDatabaseIfNotExists<BankContext>
    {
        protected override void Seed(BankContext context)
        {
            context.BankAccounts.Add(new BankAccount { AccountNumber = 110, AccountType = "Base", Amount = 50, IsClosed = false, OwnerID = "11" });
            context.BankAccounts.Add(new BankAccount { AccountNumber = 120, AccountType = "Gold", Amount = 1000, IsClosed = false, OwnerID = "12" });
            context.BankAccounts.Add(new BankAccount { AccountNumber = 130, AccountType = "Silver", Amount = 500, IsClosed = false, OwnerID = "13" });
            context.BankAccounts.Add(new BankAccount { AccountNumber = 140, AccountType = "Base", Amount = 150, IsClosed = false, OwnerID = "14" });
            context.BankAccounts.Add(new BankAccount { AccountNumber = 150, AccountType = "Platinum", Amount = 15000, IsClosed = false, OwnerID = "15" });

            base.Seed(context);
        }
    }
}
