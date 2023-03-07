using bankingProject.entities;
using BankingProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject
{
    public class MoneyMarketAccount : BankAccount
    {
        /// <summary>
        /// a type of bank account similar to savings but offers higher rate, requires higher minimum balance, and has withdrawal limit
        /// </summary>
        private const decimal interestRate = 0.03M;
        //private const decimal minimumBalance = ;
        private const int withdrawalLimit = 6;
        public MoneyMarketAccount(BankPersonnel bankPersonnel, ID id, string address, string phoneNum, string emailAdd, decimal initialDeposit, string location, string bankName)
            : base(bankPersonnel, id, address, phoneNum, emailAdd, initialDeposit, location, AccountType.MoneyMarket, bankName)
        {
        }
        public void Withdraw(decimal amount, string description, string location)
        {
            if (amount > base.Balance)
            {
                throw new ArgumentException("Withdrawal amount exceeds account balance.");
            }
            //lambda expression t => t.Type == "Withdrawal" filters out non-withdrawal type elements
            //t.Date subtracted from DateTime.Now, return TimeSpan
            //.Days property of TimeSpan, return number of whole days
            //count the number of withdrawals during the last 7 days
            if (base.TransactionHistory.Count(t => t.Type == "Withdrawal" && DateTime.Now.Subtract(t.Date).Days < 7) >= MoneyMarketAccount.withdrawalLimit)
            {
                throw new ArgumentException("Withdrawal limit exceeded.");
            }

            Transaction transaction = new Transaction(-amount, "Withdrawal", description, location);
            base.Balance -= amount;
            base.TransactionHistory.Add(transaction);
        }

        public void AddInterest()
        {
            decimal interest = base.Balance * interestRate;
            Transaction transaction = new Transaction(interest, "Interest", "", "");
            base.Balance += interest;
            base.TransactionHistory.Add(transaction);
        }
    }
}
