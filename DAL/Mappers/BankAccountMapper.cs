using System;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class BankAccountMapper
    {
        public static BankAccount FromDTO(this BankAccountDTO dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new BankAccount
            {
                IsClosed = dto.IsClosed,
                AccountNumber = dto.AccountNumber,
                AccountType = dto.Type.ToString(),
                Amount = dto.Amount,
                BonusPoints = dto.BonusPoints,
                OwnerID = dto.Owner.Passport
            };
        }

        public static BankAccountDTO ToDTO(this BankAccount account)
        {
            if (account is null)
            {
                return null;
            }

            return new BankAccountDTO(
                account.IsClosed,
                account.AccountNumber,
                new ClientDTO(account.Owner.Firstname, account.Owner.Lastname, account.Owner.PassportID, account.Owner.Email),
                account.Amount,
                account.BonusPoints,                
                (BankAccountDTO.AccountType)Enum.Parse(typeof(BankAccountDTO.AccountType), account.AccountType));
        }
    }
}
