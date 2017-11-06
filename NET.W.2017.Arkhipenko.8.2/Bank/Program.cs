using AccountService;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account.Account> accounts = new List<Account.Account>(); 

            IAccountService accountService = new AccountService.AccountService(); 
            accountService.CreateAccount(111, "Alexandra", "Arkhipenko", 100, 5, AccountType.Base);
            accountService.CreateAccount(112, "Andrey", "Petrov", 1250, 40, AccountType.Gold);
            accountService.CreateAccount(113, "Galina", "Vizovik", 10245, 120, AccountType.Premium);

            foreach (var acc in accountService.GetAllAccounts())
            {
                Console.WriteLine(acc.ToString());
            }
            Console.ReadKey();

            var account = accountService.GetAllAccounts().ToList()[0];
            accountService.AddAmount(111, 500);

            foreach (var acc in accountService.GetAllAccounts())
            {
                Console.WriteLine(acc.ToString());
            }
            Console.ReadKey();
        }
    }
}
