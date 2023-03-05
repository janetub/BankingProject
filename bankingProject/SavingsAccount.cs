using BankingProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject
{
    public class SavingsAccount : BankAccount
    {
        /// <summary>
        /// this is a child class of type, saving account
        /// </summary>
        public SavingsAccount(string name, decimal initialDeposit) : base(name, initialDeposit)
        {
            
        }
    }
}
