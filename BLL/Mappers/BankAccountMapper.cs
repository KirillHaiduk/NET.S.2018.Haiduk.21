using System;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BankAccountMapper
    {
        public static BankAccountDTO ToDalAccount(this BankAccount account)
        {
            switch (account.GetType().Name)
            {
                case "BaseBankAccount":
                    return new BankAccountDTO(account.IsClosed, account.AccountNumber, account.Client.ToDalUser(), account.Amount, account.BonusPoints, BankAccountDTO.AccountType.Base);
                case "SilverBankAccount":
                    return new BankAccountDTO(account.IsClosed, account.AccountNumber, account.Client.ToDalUser(), account.Amount, account.BonusPoints, BankAccountDTO.AccountType.Silver);
                case "GoldBankAccount":
                    return new BankAccountDTO(account.IsClosed, account.AccountNumber, account.Client.ToDalUser(), account.Amount, account.BonusPoints, BankAccountDTO.AccountType.Gold);
                case "PlatinumBankAccount":
                    return new BankAccountDTO(account.IsClosed, account.AccountNumber, account.Client.ToDalUser(), account.Amount, account.BonusPoints, BankAccountDTO.AccountType.Platinum);
                default:
                    throw new ArgumentException(nameof(account));
            }
        }

        public static BankAccount ToBllAccount(this BankAccountDTO accountDTO)
        {
            switch (accountDTO.Type)
            {
                case BankAccountDTO.AccountType.Base:
                    return new BaseBankAccount(accountDTO.IsClosed, accountDTO.AccountNumber, accountDTO.Owner.ToBllUser(), accountDTO.Amount, accountDTO.BonusPoints);
                case BankAccountDTO.AccountType.Silver:
                    return new SilverBankAccount(accountDTO.IsClosed, accountDTO.AccountNumber, accountDTO.Owner.ToBllUser(), accountDTO.Amount, accountDTO.BonusPoints);
                case BankAccountDTO.AccountType.Gold:
                    return new GoldBankAccount(accountDTO.IsClosed, accountDTO.AccountNumber, accountDTO.Owner.ToBllUser(), accountDTO.Amount, accountDTO.BonusPoints);
                case BankAccountDTO.AccountType.Platinum:
                    return new PlatinumBankAccount(accountDTO.IsClosed, accountDTO.AccountNumber, accountDTO.Owner.ToBllUser(), accountDTO.Amount, accountDTO.BonusPoints);
                default:
                    throw new ArgumentException(nameof(accountDTO));
            }
        }
    }
}
