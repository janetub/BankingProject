using bankingProject.entities;
using BankingProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject.entities
{
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// bank account type for everyday transactions such as bill payments and cash withdrawals
        /// </summary>
        private const decimal OverdraftFee = 25;

        public CheckingAccount(BankPersonnel bankPersonnel, ID id, string address, string phoneNum, string emailAdd, decimal initialDeposit, string location)
            : base(bankPersonnel, id, address, phoneNum, emailAdd, initialDeposit, location, AccountType.Checking)
        {
        }

        public void Deposit(decimal amount, string description, string location)
        {
            Transaction transaction = new Transaction(amount, "Deposit", description, location);
            base.Balance += amount;
            base.TransactionHistory.Add(transaction);
        }

        public void Withdraw(decimal amount, string description, string location)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("Withdrawal amount exceeds account balance.");
            }

            Transaction transaction = new Transaction(-amount, "Withdrawal", description, location);
            base.Balance -= amount;
            base.TransactionHistory.Add(transaction);
        }

        public void WriteCheck(decimal amount, string description, string location)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("Insufficient funds to write check.");
            }

            Transaction transaction = new Transaction(-amount, "Check", description, location);
            Balance -= amount;
            base.TransactionHistory.Add(transaction);
        }

        public void ChargeOverdraftFee()
        {
            if (base.Balance < 0)
            {
                base.Balance -= CheckingAccount.OverdraftFee;
                Transaction transaction = new Transaction(-CheckingAccount.OverdraftFee, "Overdraft Fee", "", "");
                base.TransactionHistory.Add(transaction);
            }
        }
    }
}
