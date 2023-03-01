using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string name, decimal initialDeposit) : Bankaccount(name, initialDeposit)
        {

        }
    }
}
