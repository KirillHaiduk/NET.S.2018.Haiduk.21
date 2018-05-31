using System;
using BLL.Interface.Services;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class PlatinumBankAccount inherited from BankAccount
    /// </summary>
    public class PlatinumBankAccount : BankAccount
    {
        public PlatinumBankAccount(Client client, decimal startAmount, IAccountNumberGenerator accountNumberGenerator) : base(client, startAmount, accountNumberGenerator)
        {
        }

        public PlatinumBankAccount(bool isClosed, int accountNumber, Client owner, decimal balance, double bonusPoints) : base(isClosed, accountNumber, owner, balance, bonusPoints)
        {
        }

        public override bool IsValidBalance(BankAccount account, decimal amount)
        {
            if (this.Amount < amount + 2000M)
            {
                return false;
                throw new InvalidOperationException("The amount on this account cannot be less than 2000");
            }

            return true;
        }
    }
}