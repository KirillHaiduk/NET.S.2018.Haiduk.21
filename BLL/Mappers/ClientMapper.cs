using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class ClientMapper
    {
        public static Client ToBllUser(this ClientDTO clientDTO) => new Client(clientDTO.Firstname, clientDTO.Lastname, clientDTO.Passport, clientDTO.Email);

        public static ClientDTO ToDalUser(this Client client) => new ClientDTO(client.Firstname, client.Lastname, client.Passport, client.Email);
    }
}
