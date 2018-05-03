using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IBonusCalculator
    {
        double CalculateBonusPoints(decimal amount, BankAccount account);
    }
}
