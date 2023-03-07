﻿using bankingProject.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProject
{
    public class BankAccount
    {
        /// <summary>
        /// this is a parent/base class, not meant to be instantiated
        /// </summary>
        public static int ACCOUNT_ID_COUNTER = 20230;
        public int AccountNumber { get; protected set; }
        public AccountHolder AccountHolder { get; protected set; }
        public decimal Balance { get; protected set;  }
        public DateTime DateCreated { get; protected set; }
        public AccountType AccountType { get; protected set; }
        public List<Transaction> TransactionHistory { get; protected set; }

        public BankAccount(BankPersonnel bankPersonnel, ID id, string address, string phoneNum, string emailAdd, decimal initialDeposit, string location, AccountType accountType)
        {
            if (bankPersonnel is not BankPersonnel && bankPersonnel.ID.IsVerified)
            {
                throw new ArgumentException("Creator is not a credible bank personnel.");
            }
            AccountHolder accountHolder = new AccountHolder(bankPersonnel, id, address, phoneNum, emailAdd);
            this.AccountHolder = accountHolder;
            this.AccountNumber = BankAccount.ACCOUNT_ID_COUNTER++;
            this.Balance = initialDeposit;
            this.DateCreated = DateTime.Now;
            Transaction transaction = new Transaction(initialDeposit, "Account Opening", "", location);
            this.TransactionHistory.Add(transaction);
            this.AccountType = accountType;

        }
    }
}
