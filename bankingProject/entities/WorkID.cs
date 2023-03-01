using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingProject.entities
{
    public class WorkID : ID
    {
        public string EmployerName { get; }
        public string CompanyName { get; }
        public string JobTitle { get; }

        public WorkID(string idNumber, string name, DateTime birthDate, string nationality, string employerName, string companyName, string jobTitle) : base(idNumber, name, birthDate, nationality)
        {
            this.EmployerName = employerName;
            this.CompanyName = companyName;
            this.JobTitle = jobTitle;
        }
    }
}
