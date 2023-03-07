using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject.entities
{
    public class Transaction
    {
        /// <summary>
        /// this class will act as a single log of a bank account's transaction
        /// </summary>
        public decimal Amount { get; }
        public string Type { get; }
        public DateTime Date { get; }  
        public string Desciption { get; }
        public string Location { get; }
        public Transaction (decimal amount, string type, string description, string location)
        {
            this.Amount = amount;
            this.Type = type;
            this.Date = DateTime.Now;
            this.Desciption = description;
            this.Location = location;
        }
        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}\nTransaction Type: {Type}\nAmount: {Amount}\nDescription: {Desciption}\nLocation: {Location}\n\n";
        }
    }
}
