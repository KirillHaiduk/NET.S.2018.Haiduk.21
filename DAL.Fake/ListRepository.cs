using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Repository;

namespace DAL.Fake
{
    public class ListRepository : IRepository
    {
        private List<BankAccountDTO> bankAccounts = new List<BankAccountDTO>();

        /// <summary>
        /// Method for adding new account into Account repository
        /// </summary>
        /// <param name="client">Owner of account</param>
        /// <param name="startAmount">Value of start amount</param>
        public void Create(ClientDTO client, decimal startAmount)
        {
            if (startAmount >= 0m && startAmount < 1000m)
            {
                var account = new BankAccountDTO(false, 0, client, startAmount, 0, BankAccountDTO.AccountType.Base);
                bankAccounts.Add(account);
            }
            else if (startAmount >= 1000m && startAmount < 5000m)
            {
                var account = new BankAccountDTO(false, 0, client, startAmount, 0, BankAccountDTO.AccountType.Silver);
                bankAccounts.Add(account);
            }
            else if (startAmount >= 5000m && startAmount < 10000m)
            {
                var account = new BankAccountDTO(false, 0, client, startAmount, 0, BankAccountDTO.AccountType.Gold);
                bankAccounts.Add(account);
            }
            else if (startAmount >= 10000m)
            {
                var account = new BankAccountDTO(false, 0, client, startAmount, 0, BankAccountDTO.AccountType.Platinum);
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
        public BankAccountDTO Read(ClientDTO client) => bankAccounts.Where(b => b.Owner == client).FirstOrDefault();

        /// <summary>
        /// Method for updating information about existing account in repository
        /// </summary>
        public void Update(BankAccountDTO account)
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
