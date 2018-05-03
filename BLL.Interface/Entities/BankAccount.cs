using System;
using BLL.Interface.Services;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class that describes Bank Account and contains methods for working with it
    /// </summary>
    public abstract class BankAccount
    {
        #region Fields        

        protected readonly int AccNumber;

        protected readonly Client Owner;

        protected decimal amount;

        protected bool closed;

        #endregion        

        /// <summary>
        /// Constructor for creating new Bank account
        /// </summary>
        /// <param name="client">Information about account owner</param>
        /// <param name="startAmount">Value of star amount</param>
        public BankAccount(Client client, decimal startAmount, IAccountNumberGenerator accountNumberGenerator)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (startAmount < 0)
            {
                throw new ArgumentException(nameof(startAmount));
            }

            if (accountNumberGenerator is null)
            {
                throw new ArgumentNullException(nameof(accountNumberGenerator));
            }

            this.AccNumber = SetAccountNumber(accountNumberGenerator);
            this.Owner = client;
            this.amount = startAmount;
            closed = false;
            BonusPoints = 0;
        }

        #region Properties

        /// <summary>
        /// The ID number of Bank Account
        /// </summary>
        public int AccountNumber => AccNumber;

        /// <summary>
        /// Firstname of the owner of Bank Account
        /// </summary>
        public string OwnerInfo => Owner.ToString();

        /// <summary>
        /// The owner of Bank Account
        /// </summary>
        public Client Client => Owner;

        /// <summary>
        /// The owner of Bank Account
        /// </summary>
        public bool IsClosed => closed;

        /// <summary>
        /// Amount of Bank Account
        /// </summary>
        public decimal Amount
        {
            get => amount;
            set
            {
                amount = value;
            }
        }

        /// <summary>
        /// Bonus Points that add or substarct while working with amount
        /// </summary>
        public double BonusPoints { get; set; }

        #endregion

        /// <summary>
        /// Method for calculating Bonus points
        /// </summary>
        /// <param name="amount">Amount of money for deposit or withdraw</param>
        /// <param name="bonusCalculator">Instance of Bonus calculator to determine type of bonus points calculation</param>
        /// <param name="bankAccount">Account for calculating bonus points</param>
        /// <returns>Value of bonus points after money operations with account</returns>
        public double CalculateBonusPoints(decimal amount, IBonusCalculator bonusCalculator, BankAccount bankAccount) => bonusCalculator.CalculateBonusPoints(amount, bankAccount);

        /// <summary>
        /// Method for determining whether withdraw operation is valid with given account
        /// </summary>
        /// <param name="account">Given account</param>
        /// <param name="amount">Amount of money for withdraw</param>
        /// <returns>True if account is valid for withdraw; otherwise, false</returns>
        public abstract bool IsValidBalance(BankAccount account, decimal amount);

        protected int SetAccountNumber(IAccountNumberGenerator accountNumberGenerator) => accountNumberGenerator.GenerateNewAccountNumber();
    }
}