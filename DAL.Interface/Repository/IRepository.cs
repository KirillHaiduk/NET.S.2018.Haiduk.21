using BLL.Interface.Entities;
using BLL.Interface.Services;

namespace DAL.Interface.Repository
{
    public interface IRepository
    {
        void Create(Client client, decimal startAmount, IAccountNumberGenerator accountNumberGenerator);

        BankAccount Read(Client client);

        void Update(BankAccount account);

        void Delete(int accountNumber);
    }
}
