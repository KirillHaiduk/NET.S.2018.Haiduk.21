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
                var account1 = new BankAccount() { AccountNumberID = 12, AccountType = "Base", IsClosed = false, Amount = 100M };
                var account2 = new BankAccount() { AccountNumberID = 13, AccountType = "Gold", IsClosed = false, Amount = 1000M };
                var account3 = new BankAccount() { AccountNumberID = 14, AccountType = "Platinum", IsClosed = false, Amount = 50000M };
                var account4 = new BankAccount() { AccountNumberID = 15, AccountType = "Base", IsClosed = false, Amount = 130M };

                ctx.BankAccounts.Add(account1);
                ctx.BankAccounts.Add(account2);
                ctx.BankAccounts.Add(account3);
                ctx.BankAccounts.Add(account4);
                Console.WriteLine("new accounts added");
                ctx.SaveChanges();
            }

            using (var ctx = new BankContext())
            {
                var accounts = ctx.BankAccounts.Where(a => a.AccountType == "Base");
                foreach (var acc in accounts)
                {
                    Console.WriteLine(acc.AccountNumberID + " " + acc.Amount);
                }
            }

            Console.ReadLine();
        }
    }
}
