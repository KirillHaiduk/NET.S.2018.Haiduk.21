using System.Collections.Generic;

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

        /// <summary>
        /// Defining operator '==' for comparing two Client instances
        /// </summary>
        /// <param name="clientA">1st Client instance</param>
        /// <param name="clientB">2nd Client instance</param>
        /// <returns>True if instances are equal; otherwise, false</returns>
        public static bool operator ==(ClientDTO clientA, ClientDTO clientB) => clientA.Firstname == clientB.Firstname && clientA.Lastname == clientB.Lastname && clientA.Passport == clientB.Passport;

        /// <summary>
        /// Defining operator '!=' for comparing two Client instances
        /// </summary>
        /// <param name="clientA">1st Client instance</param>
        /// <param name="clientB">2nd Client instance</param>
        /// <returns>True if instances are not equal; otherwise, false</returns>
        public static bool operator !=(ClientDTO clientA, ClientDTO clientB) => clientA.Firstname != clientB.Firstname || clientA.Lastname != clientB.Lastname || clientA.Passport != clientB.Passport;

        /// <summary>
        /// Defines equality of two instances of Client
        /// </summary>
        /// <param name="other">Given Client instance</param>
        /// <returns>True if Client instance is equal to given; otherwise, false</returns>
        public bool Equals(ClientDTO other)
        {
            return !(other is null) &&
                   Firstname == other.Firstname &&
                   Lastname == other.Lastname &&
                   Passport == other.Passport &&
                   Email == other.Email;
        }

        /// <summary>
        /// Overriding of System.Object method Equals
        /// </summary>
        /// <param name="obj">Given object to compare with Client instance</param>
        /// <returns>True if Client instance is equal to given object; otherwise, false</returns>        
        public override bool Equals(object obj)
        {
            var client = obj as ClientDTO;
            return this.Equals(client);
        }

        /// <summary>
        /// Overriding of System.Object method GetHashCode
        /// </summary>
        /// <returns>Hashcode of Client instance</returns>
        public override int GetHashCode()
        {
            var hashCode = 2056398814;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Firstname);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Lastname);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Passport);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Email);
            return hashCode;
        }
    }
}
