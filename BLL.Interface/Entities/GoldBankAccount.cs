using System;
using BLL.Interface.Services;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class GoldBankAccount inherited from BankAccount
    /// </summary>
    public class GoldBankAccount : BankAccount
    {
        public GoldBankAccount(Client client, decimal startAmount, IAccountNumberGenerator accountNumberGenerator) : base(client, startAmount, accountNumberGenerator)
        {
        }

        public GoldBankAccount(bool isClosed, int accountNumber, Client owner, decimal balance, double bonusPoints) : base(isClosed, accountNumber, owner, balance, bonusPoints)
        {
        }

        public override bool IsValidBalance(BankAccount account, decimal amount)
        {
            if (this.Amount < amount + 1000M)
            {
                return false;
                throw new InvalidOperationException("The amount on this account cannot be less than 1000");
            }

            return true;
        }
    }
}