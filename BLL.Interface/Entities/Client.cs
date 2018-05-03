using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class that describes Bank client
    /// </summary>
    public class Client
    {
        private string firstname;

        private string lastname;

        private string passport;

        private string email;

        /// <summary>
        /// Constructor for creating Client instance
        /// </summary>
        /// <param name="firstname">Firstname of new client</param>
        /// <param name="lastname">Lastname of new client</param>
        /// <param name="passport">Passport number of new client</param>
        /// <param name="email">Email of new client</param>
        public Client(string firstname, string lastname, string passport, string email)
        {
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(passport) || string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Invalid client data");
            }

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
        
        /// <summary>
        /// Defining operator '==' for comparing two Client instances
        /// </summary>
        /// <param name="clientA">1st Client instance</param>
        /// <param name="clientB">2nd Client instance</param>
        /// <returns>True if instances are equal; otherwise, false</returns>
        public static bool operator ==(Client clientA, Client clientB) => clientA.Firstname == clientB.Firstname && clientA.Lastname == clientB.Lastname && clientA.Passport == clientB.Passport;

        /// <summary>
        /// Defining operator '!=' for comparing two Client instances
        /// </summary>
        /// <param name="clientA">1st Client instance</param>
        /// <param name="clientB">2nd Client instance</param>
        /// <returns>True if instances are not equal; otherwise, false</returns>
        public static bool operator !=(Client clientA, Client clientB) => clientA.Firstname != clientB.Firstname || clientA.Lastname != clientB.Lastname || clientA.Passport != clientB.Passport;

        /// <summary>
        /// Defines equality of two instances of Client
        /// </summary>
        /// <param name="other">Given Client instance</param>
        /// <returns>True if Client instance is equal to given; otherwise, false</returns>
        public bool Equals(Client other)
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
            var client = obj as Client;
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

        /// <summary>
        /// String representation of Client instance
        /// </summary>
        /// <returns>Information about client as string</returns>
        public override string ToString() => string.Format("Firstame: {0}\nLastname: {1}\nPassport number: {2}\nEmail: {3}", this.Firstname, this.Lastname, this.Passport, this.Email);
    }
}