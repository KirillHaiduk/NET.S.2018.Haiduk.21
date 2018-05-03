using System;
using BLL.Interface.Services;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class SilverBankAccount inherited from BankAccount
    /// </summary>
    public class SilverBankAccount : BankAccount
    {
        public SilverBankAccount(Client client, decimal startAmount, IAccountNumberGenerator accountNumberGenerator) : base(client, startAmount, accountNumberGenerator)
        {
        }

        public override bool IsValidBalance(BankAccount account, decimal amount)
        {
            if (this.Amount < amount + 500M)
            {
                return false;
                throw new InvalidOperationException("The amount on this account cannot be less than 500");
            }

            return true;
        }
    }
}