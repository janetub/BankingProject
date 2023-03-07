using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject.entities
{
    public class AccountHolder
    {
        /// <summary>
        /// this class will contain the information that might be vital to the processes in banking
        /// </summary>
        protected internal string name { get; private set; }
        protected internal string address { get; private set; }
        protected internal int age { get; private set; }
        protected internal DateTime birthDate { get; private set; }
        protected internal string nationality { get; private set; }
        protected internal ArrayList phoneNumbers { get; private set; }
        protected internal ArrayList emailAddress { get; private set; }
        protected internal Dictionary<string, string> validIDs { get; private set; }  
        /// <summary>
        /// Account Holder Constructor
        /// </summary>
        /// <param name="bankPersonnel">person authorised to modify this object</param>
        /// <param name="id">where details about holder are copied</param>
        /// <param name="address">contact detail pf holder</param>
        /// <param name="phoneNum">contact detail of holder</param>
        /// <param name="emailAdd">contact detail of holder</param>
        /// <exception cref="ArgumentException"></exception>
        public AccountHolder(BankPersonnel bankPersonnel, ID id, string address, string phoneNum, string emailAdd)
        {
            if (bankPersonnel is not BankPersonnel && bankPersonnel.ID.IsVerified)
            {
                throw new ArgumentException("Creator is not a credible bank personnel.");
            }
            this.name = id.Name;
            this.address = address;
            this.age = id.Age;
            this.birthDate = id.BirthDate;
            this.nationality = id.Nationality;
            this.phoneNumbers.Add(phoneNum);
            this.emailAddress.Add(emailAdd);
        }
        public void AddID(BankPersonnel bankPersonnel, ID id)
        {
            if (id.IsVerified)
            {
                validIDs.Add(id.IDNumber, id.IDType);
            }
            else
            {
                throw new UnauthorizedAccessException($"ID number {id.IDNumber} must be verified.");
            }
        }
        public void RemoveID(BankPersonnel bankPersonnel, ID id)
        {
            if (!bankPersonnel.ID.IsVerified)
                return;
            validIDs.Remove(id.IDNumber);
        }
        public void AddPhoneNumber(BankPersonnel bankPersonnel, string phoneNumber)
        {
            if (!bankPersonnel.ID.IsVerified)
                return;
            this.phoneNumbers.Add(phoneNumber);
        }
        public void RemovePhoneNumber(BankPersonnel bankPersonnel, string phoneNumber)
        {
            if (!bankPersonnel.ID.IsVerified)
                return;
            this.phoneNumbers.Remove(phoneNumber);
        }
        public void AddEmailAddress(BankPersonnel bankPersonnel, string email)
        {
            if (!bankPersonnel.ID.IsVerified)
                return;
            this.emailAddress.Add(email);
        }
        public void RemoveEmailAddress(BankPersonnel bankPersonnel, string email)
        {
            if (!bankPersonnel.ID.IsVerified)
                return;
            this.emailAddress.Remove(email);
        }
        public void UpdateName(BankPersonnel bankPersonnel, string name)
        {
            if (!bankPersonnel.ID.IsVerified)
                throw new UnauthorizedAccessException("Access denied.");
            this.name = name;
        }
        public void UpdateAddress(BankPersonnel bankPersonnel, string address)
        {
            if (!bankPersonnel.ID.IsVerified)
                throw new UnauthorizedAccessException("Access denied.");
            this.address = address;
        }
        
    }
}
