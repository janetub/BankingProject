using bankingProject.entities;
using BankingProject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject
{
    public class ATMMachine
    {
        /// <summary>
        /// represents an actual ATM machine
        /// </summary>
        public string BankName;
        public string Branch { get; private set; }
        public ATMMachine (string bankName, string branch)
        {
            this.BankName = bankName;
            this.Branch = branch;
        }
        public void Withdraw(Card card, int pin, int amount)
        {
            try
            {
               // withdrawal for each account type
                BankAccount account = card.OpenAccount(pin);
                account.Withdraw(amount, $"Withdrawwal of {amount} in {this.BankName} - {this.Branch}", $"{this.BankName} - {this.Branch}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid pin");
            }
        }
        public void ChangePin(Card card, int old_pin, int new_pin)
        {
            try
            {
                card.ChangePin(old_pin, new_pin);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Invalid Pin.");
            }
        }
    }
}
