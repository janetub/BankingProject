using BankingProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject.entities
{
    public class Card
    {
        public string OwnerName { get; private set; }
        public string CardNumber { get; private set; }
        private BankAccount Account { get; set; }
        private int pin { get; set; }
        public Card(string name, string cardNumber, BankAccount account, int pin)
        {
            this.OwnerName = name;
            this.CardNumber = cardNumber;
            this.Account = account;
            this.pin = pin;
        }
        public BankAccount OpenAccount(int pin)
        {
            if (pin != this.pin)
                throw new ArgumentException("Invalid pin.");
            return this.Account;
        }
        public void ChangePin(int old_pin, int new_pin)
        {
            if (old_pin != this.pin)
                throw new ArgumentException("Invalid pin.");
            this.pin = new_pin;
        }
    }
}
