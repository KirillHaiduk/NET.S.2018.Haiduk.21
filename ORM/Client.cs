using System.Collections.Generic;

namespace ORM
{
    public class Client
    {
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
        public string PassportID { get; set; }

        /// <summary>
        /// Email adress of client
        /// </summary>
        public string Email { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
