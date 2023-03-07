using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject.entities
{
    public class BankPersonnel
    {
        /// <summary>
        /// a bank personnel will be athorized to edit the AccountHolder which contains information that is used for the banking processes
        /// </summary>
        public WorkID ID {  get; }
        public string Email { get; set; }
        public BankingPersonnel (WorkID id, string email)
        {
            this.ID = id;
            this.Email = email;
        }
    }
}
