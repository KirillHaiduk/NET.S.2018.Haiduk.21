using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IRepository
    {
        void Create(ClientDTO client, decimal startAmount);

        BankAccountDTO Read(ClientDTO client);

        void Update(BankAccountDTO account);

        void Delete(int accountNumber);
    }
}
