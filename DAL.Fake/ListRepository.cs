using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;

namespace DAL.Fake
{
    public class ListRepository : IRepository
    {
        private List<BankAccount> bankAccounts = new List<BankAccount>();

        /// <summary>
        /// Method for adding new account into Account repository
        /// </summary>
        /// <param name="client">Owner of account</param>
        /// <param name="startAmount">Value of start amount</param>
        public void Create(Client client, decimal startAmount, IAccountNumberGenerator accountNumberGenerator)
        {
            if (startAmount >= 0m && startAmount < 1000m)
            {
                var account = new BaseBankAccount(client, startAmount, accountNumberGenerator);
                bankAccounts.Add(account);
            }
            else if (startAmount >= 1000m && startAmount < 5000m)
            {
                var account = new SilverBankAccount(client, startAmount, accountNumberGenerator);
                bankAccounts.Add(account);
            }
            else if (startAmount >= 5000m && startAmount < 10000m)
            {
                var account = new GoldBankAccount(client, startAmount, accountNumberGenerator);
                bankAccounts.Add(account);
            }
            else if (startAmount >= 10000m)
            {
                var account = new PlatinumBankAccount(client, startAmount, accountNumberGenerator);
                bankAccounts.Add(account);
            }
        }

        /// <summary>
        /// Method for deleting existing account from Account repository
        /// </summary>
        /// <param name="accountNumber">Number of account to delete</param>
        public void Delete(int accountNumber) => bankAccounts.Remove(bankAccounts.Where(b => b.AccountNumber == accountNumber).FirstOrDefault());

        /// <summary>
        /// Method for retrieving account from Account repository
        /// </summary>
        /// <param name="client">Information about account owner</param>
        /// <returns>Account of accepted owner</returns>
        public BankAccount Read(Client client) => bankAccounts.Where(b => b.Client == client).FirstOrDefault();

        /// <summary>
        /// Method for updating information about existing account in repository
        /// </summary>
        public void Update(BankAccount account)
        {
            int index = bankAccounts.FindIndex(b => b.AccountNumber == account.AccountNumber);
            if (index >= 0)
            {
                bankAccounts.RemoveAt(index);
                bankAccounts.Insert(index, account);
            }
            else
            {
                throw new ArgumentException($"Account with Account Number { account.AccountNumber } not found");
            }
        }
    }
}
