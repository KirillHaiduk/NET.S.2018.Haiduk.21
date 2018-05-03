using System;
using BLL.Interface.Services;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class BaseBankAccount inherited from BankAccount
    /// </summary>
    public class BaseBankAccount : BankAccount
    {
        public BaseBankAccount(Client client, decimal startAmount, IAccountNumberGenerator accountNumberGenerator) : base(client, startAmount, accountNumberGenerator)
        {
        }

        public override bool IsValidBalance(BankAccount account, decimal amount)
        {
            if (this.Amount <= amount)
            {
                return false;
                throw new InvalidOperationException("The amount on this account cannot be less than 0");
            }

            return true;
        }
    }
}