using DAL.Interface.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class ClientMapper
    {
        public static Client FromDTO(this ClientDTO dto) => new Client() { Firstname = dto.Firstname, Lastname = dto.Lastname, PassportID = dto.Passport, Email = dto.Email };

        public static ClientDTO ToDTO(this Client owner) => new ClientDTO(owner.Firstname, owner.Lastname, owner.PassportID, owner.Email);
    }
}
