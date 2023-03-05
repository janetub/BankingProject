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
        private string _name;
        private string _address;
        private int _age;
        private DateTime _birthDate;
        private string _nationality;
        private ArrayList _phoneNumbers;
        private ArrayList _emailAddress;
        private Dictionary<string, string> validIDs;
        private string _transactions; //
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
            if (bankPersonnel is not BankPersonnel && bankPersonnel.id.IsVerified)
            {
                throw new ArgumentException("Creator is not a credible bank personnel.");
            }
            this._name = id.Name;
            this._address = address;
            this._age = id.Age;
            this._birthDate = id.BirthDate;
            this._nationality = id.Nationality;
            this._phoneNumbers.Add(phoneNum);
            this._emailAddress.Add(emailAdd);
        }
        public void AddID(ID id)
        {
            if (id.IsVerified)
            {
                validIDs.Add(id.IDNumber, id.IDType);
            }
            else
            {
                throw new UnauthorizedAccessException("ID number {id.number} must be verified.");
            }
        }
        public void RemoveID(ID id)
        {
            validIDs.Remove(id.IDNumber);
        }
        public void AddPhoneNumber(string phoneNumber)
        {
            this._phoneNumbers.Add(phoneNumber);
        }
        public void RemovePhoneNumber(string phoneNumber)
        {
            this._phoneNumbers.Remove(phoneNumber);
        }
        public void AddEmailAddress(string email)
        {
            this._emailAddress.Add(email);
        }
        public void RemoveEmailAddress(string email)
        {
            this._emailAddress.Remove(email);
        }
    }
}
