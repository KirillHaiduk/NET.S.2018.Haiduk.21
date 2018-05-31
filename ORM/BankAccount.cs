namespace ORM
{
    public class BankAccount
    {
        public int AccountNumberID { get; set; }

        public bool IsClosed { get; set; }
                
        public int AccountNumber { get; set; }

        public decimal Amount { get; set; }

        public double BonusPoints { get; set; }

        public string AccountType { get; set; }

        public string OwnerID { get; set; }

        public virtual Client Owner { get; set; }
    }
}
