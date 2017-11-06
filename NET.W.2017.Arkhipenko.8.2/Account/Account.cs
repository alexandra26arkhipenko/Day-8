using System;

namespace Account
{
    public class Account
    {

        public int Id { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public decimal Amount { get; set; }
        public int Points { get; set; }
        public StatusAccount Status { get; set; }
        public AccountType Type { get; set; }
        
        public Account()
        {
        }

        public Account(int id, string ownerFirstName, string ownerLastName, decimal amount, int points, AccountType type)
        {
            Id = id;
            OwnerFirstName = ownerFirstName;
            OwnerLastName = ownerLastName;
            Amount = amount;
            Points = points;
            Status = StatusAccount.Active;
            Type = type;
        }

        public override string ToString()
        {
            return String.Format("Account №{0}\n Owner: {1} {2} \n Amount: {3}$  points:{4}\n Status: {5}  Type: {6}",
                Id, OwnerFirstName,
                OwnerLastName, Amount, Points, Status, Type);
        }
    }
}

