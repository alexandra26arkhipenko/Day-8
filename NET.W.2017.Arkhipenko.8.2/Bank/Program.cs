using AccountService;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            accountService.CreateAccount(new Account.Account(111, "Alexandra", "Arkhipenko", 100m, 5, AccountType.Base));
            accountService.CreateAccount(new Account.Account(112, "Andrey", "Petrov", 1250m, 40, AccountType.Gold));
            accountService.CreateAccount(new Account.Account(113, "Galina", "Vizovik", 10245m, 120, AccountType.Premium));

            Print(accountService.GetAllAccounts());
           
            accountService.AddAmount(111, 500m);
            Print(accountService.GetAllAccounts());

            accountService.CloseAccount(112);
            Print(accountService.GetAllAccounts());

            accountService.DivAmount(113, 100m);
            Print(accountService.GetAllAccounts());

            Console.ReadKey();

        }

        private static void Print(IEnumerable<Account.Account> accounts)
        {
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc.ToString());
            }
            Console.WriteLine();
        }
    }
}
