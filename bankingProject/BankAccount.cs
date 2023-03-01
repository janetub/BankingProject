using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject
{
    public class BankAccount
    {
        public static int ACCOUNT_ID_COUNTER = 20230;
        public int AccountNumber { get; private set; }
        public string AccountName { get; set; }
        public decimal Balance { get; private set;  }
        public DateTime DateCreated { get; private set; }

        public BankAccount(string name, decimal initialDeposit)
        {
            this.AccountNumber = BankAccount.ACCOUNT_ID_COUNTER++;
            this.AccountName = name;
            this.Balance = initialDeposit;
            this.DateCreated = DateTime.Now;
        }
    }
}
