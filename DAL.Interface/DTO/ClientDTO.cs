namespace DAL.Interface.DTO
{
    public class ClientDTO
    {        
        public ClientDTO(string firstname, string lastname, string passport, string email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Passport = passport;
            Email = email;
        }

        /// <summary>
        /// Firstname of client
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Lastname of client
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Passport number of client
        /// </summary>
        public string Passport { get; set; }

        /// <summary>
        /// Email adress of client
        /// </summary>
        public string Email { get; set; }
    }
}
