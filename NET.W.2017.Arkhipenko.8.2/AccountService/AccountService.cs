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
        #region private fild
        private readonly AccountStorage.AccountStorage _accountStorage;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor 
        /// </summary>
        public AccountService()
        {
            _accountStorage = new AccountStorage.AccountStorage();
        }
        #endregion

        #region public
        /// <summary>
        /// GetAllAccounts returns all elements of file 
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Account.Account> GetAllAccounts()
        {
            return _accountStorage.ReadAccountFromFile();
        }

        /// <summary>
        /// AddAmount increases amount field
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
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

        /// <summary>
        /// DivAmmount decrease amount field
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void DivAmount(int id, decimal amount)
        {
            var account = FindAccount(id);
            if (account.Status == StatusAccount.Close) throw new ArgumentException("Account is closed");
            account.Amount = account.Amount - amount;
        }

        /// <summary>
        /// CreateAccount create new account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownerFirstName"></param>
        /// <param name="ownerLastName"></param>
        /// <param name="amount"></param>
        /// <param name="points"></param>
        /// <param name="type"></param>
        public void CreateAccount(Account.Account account)
        {
            var accounts = _accountStorage.ReadAccountFromFile().ToList();
            accounts.Add(account);

            _accountStorage.OverWriteFile(accounts);
        }

        /// <summary>
        /// CloseAccount assigns account statues fild Close
        /// </summary>
        /// <param name="id"></param>
        public void CloseAccount(int id)
        {
            if(id < 0) throw new ArgumentException();

            var account = FindAccount(id);
            account.Status = StatusAccount.Close;
        }

        #endregion
        #region private
        private Account.Account FindAccount(int id)
        {

            var accounts = _accountStorage.ReadAccountFromFile().ToList();
            return accounts.FirstOrDefault(account => account.Id == id);
        }
#endregion
    }
}
