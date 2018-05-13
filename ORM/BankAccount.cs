namespace ORM
{
    public class BankAccount
    {        
        public bool IsClosed { get; set; }
                
        public int AccountNumberID { get; set; }        

        public decimal Amount { get; set; }

        public double BonusPoints { get; set; }

        public string AccountType { get; set; }

        public string OwnerID { get; set; }

        public virtual Client Owner { get; set; }
    }
}
