using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject.entities
{
    public class ID
    {
        public string IDNumber  { get; }
        public bool IsVerified  { get; private set; }
        public string Name { get; }
        public DateTime BirthDate { get; }
        public int Age { get; }
        public string Nationality { get; }
        public string IDType { get; }

        public ID(string idType, string idNumber, string name, DateTime birthDate, string nationality)
        {
            this.IDType = idType; 
            this.IDNumber = idNumber;
            this.IsVerified = false;
            this.Name = name;
            this.BirthDate = birthDate;
            this.Age = setAge(birthDate);
            this.Nationality = nationality;
        }
        private int setAge(DateTime birthDate)
        {
            ///derived from birth date
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-age))
                age--;
            return age;
        }
        public void Verify()
        {
            //add verification conditions
            this.IsVerified = true;
        }

        /*public string IdNumber
        {
            get
            {
                return _idNumber;
            }
        }
        public bool IsVerified
        {
            get
            {
                return _isVerified;
            }
        }
        public string Name
        { get { return _name; } }
        public DateTime BirthDate
        { get { return _birthDate; } }
        public int Age
        { get { return _age; } }
        public string Nationality
        { get { return _nationality; } }*/

    }
}
