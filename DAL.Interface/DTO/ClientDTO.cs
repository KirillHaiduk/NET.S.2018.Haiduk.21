namespace DAL.Interface.DTO
{
    public class ClientDTO
    {
        private string firstname;

        private string lastname;

        private string passport;

        private string email;

        public ClientDTO(string firstname, string lastname, string passport, string email)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.passport = passport;
            this.email = email;
        }

        /// <summary>
        /// Firstname of client
        /// </summary>
        public string Firstname => firstname;

        /// <summary>
        /// Lastname of client
        /// </summary>
        public string Lastname => lastname;

        /// <summary>
        /// Passport number of client
        /// </summary>
        public string Passport => passport;

        /// <summary>
        /// Email adress of client
        /// </summary>
        public string Email => email;
    }
}
