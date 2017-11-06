using System;
using System.Collections.Generic;
using System.Linq;
using Account;
using Interfaces;
using AccountStorage;


namespace AccountService
{
    public class AccountService : IAccountService
    {
        private readonly AccountStorage.AccountStorage _accountStorage;

        public AccountService()
        {
            _accountStorage = new AccountStorage.AccountStorage();
        }

        public IEnumerable<Account.Account> GetAllAccounts()
        {
            return _accountStorage.ReadAccountFromFile();
        }

        public void AddAmount(int id, decimal amount)
        {
            var account = FindAccount(id);
            if (account.Status == StatusAccount.Close) throw new ArgumentException("Account is closed");
            account.Amount = account.Amount + amount;

            if (account.Type == AccountType.Base)
                account.Points += 10;

            if (account.Type == AccountType.Gold)
                account.Points += 20;

            if (account.Type == AccountType.Premium)
                account.Points += 30;
        }

        public void DivAmount(int id, decimal amount)
        {
            var account = FindAccount(id);
            if (account.Status == StatusAccount.Close) throw new ArgumentException("Account is closed");
            account.Amount = account.Amount - amount;
        }

        public void CreateAccount(int id,string ownerFirstName, string ownerLastName, decimal amount, int points, AccountType type)
        {
            var accounts = _accountStorage.ReadAccountFromFile().ToList();
            accounts.Add(new Account.Account( id, ownerFirstName, ownerLastName, amount, points, type));
            _accountStorage.OverWriteFile(accounts);
        }

        public void CloseAccount(int id)
        {
            if(id == null) throw new ArgumentNullException();

            var account = FindAccount(id);
            account.Status = StatusAccount.Close;
        }
        private Account.Account FindAccount(int id)
        {

            var accounts = _accountStorage.ReadAccountFromFile().ToList();
            return accounts.FirstOrDefault(account => account.Id == id);
        }

    }
}
