using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class BLLEntityMappers
    {
        public static Client ToDalUser(this ClientDTO clientDTO) => new Client(clientDTO.Firstname, clientDTO.Lastname, clientDTO.Passport, clientDTO.Email);

        public static ClientDTO ToBllUser(this Client client) => new ClientDTO(client.Firstname, client.Lastname, client.Passport, client.Email);
    }
}
