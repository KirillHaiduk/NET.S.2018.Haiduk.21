namespace DAL.Interface.DTO
{
    public class BankAccountDTO
    {
        public BankAccountDTO(bool isClosed, int accountNumber, ClientDTO owner, decimal balance, double bonusPoints, AccountType type)
        {
            IsClosed = isClosed;
            AccountNumber = accountNumber;
            Owner = owner;
            Amount = balance;
            BonusPoints = bonusPoints;
            Type = type;
        }

        /// <summary>
        /// Types of Bank account
        /// </summary>
        public enum AccountType
        {
            Base,
            Silver,
            Gold,
            Platinum
        }

        /// <summary>
        /// Determines whether account is closed
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Number of Bank account
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Owner of Bank account
        /// </summary>
        public ClientDTO Owner { get; set; }

        /// <summary>
        /// Amount of Bank account
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Bonus points of Bank account
        /// </summary>
        public double BonusPoints { get; set; }

        /// <summary>
        /// Type of Bank account
        /// </summary>
        public AccountType Type { get; set; }
    }
}
