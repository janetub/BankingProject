using bankingProject.entities;
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
        /// savings account type is for money saving which offers higher interest than checking
        /// </summary>
        public SavingsAccount (BankPersonnel bankPersonnel, ID id, string address, string phoneNum, string emailAdd, decimal initialDeposit, string location, string bankName) : base(bankPersonnel, id, address, phoneNum, emailAdd, initialDeposit, location, AccountType.Savings, bankName)
        {
        }

        public void Deposit (decimal amount, string description, string location)
        {
            Transaction transaction = new Transaction(amount, "Deposit", description, location);
            base.Balance += amount;
            base.TransactionHistory.Add(transaction);
        }

        public void Withdraw (decimal amount, string description, string location)
        {
            if (amount > base.Balance)
            {
                throw new ArgumentException("Withdrawal amount exceeds account balance.");
            }

            Transaction transaction = new Transaction(-amount, "Withdrawal", description, location);
            base.Balance -= amount;
            TransactionHistory.Add(transaction);
        }

        public decimal CalculateInterest (int years, decimal interestRate)
        {
            decimal interest = base.Balance * (decimal)Math.Pow(1 + (double)interestRate, years) - base.Balance;
            return interest;
        }
    }
}
