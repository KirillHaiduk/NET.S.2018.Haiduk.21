using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Program
    {
        public static void Main()
        {
            using (var ctx = new BankContext())
            {
                var account = new BankAccount() { AccountNumberID = 12, AccountType = "Base", IsClosed = false };

                ctx.BankAccounts.Add(account);
                ctx.SaveChanges();
            }
        }
    }
}
