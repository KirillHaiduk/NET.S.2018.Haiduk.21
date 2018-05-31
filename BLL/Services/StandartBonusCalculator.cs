using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class StandartBonusCalculator : IBonusCalculator
    {
        public double CalculateBonusPoints(decimal amount, BankAccount account)
        {
            switch (account.GetType().Name)
            {
                case "BaseBankAccount":
                    return (double)((account.Amount + amount) * 0.0001m);
                case "SilverBankAccount":
                    return (double)((account.Amount + amount) * 0.001m);
                case "GoldBankAccount":
                    return (double)((account.Amount + amount) * 0.01m);
                case "PlatinumBankAccount":
                    return (double)((account.Amount + amount) * 0.1m);
                default:
                    return 0;
            }
        }
    }
}
