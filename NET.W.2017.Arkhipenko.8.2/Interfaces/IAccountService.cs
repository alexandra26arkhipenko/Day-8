using System;
using System.Collections.Generic;
using Account;

namespace Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account.Account> GetAllAccounts();
        void AddAmount(int id, decimal amount);
        void DivAmount(int id, decimal amount);
        void CloseAccount(int id);
        void CreateAccount(Account.Account account);
    }
}