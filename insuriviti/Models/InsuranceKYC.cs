using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace insuriviti.Models
{
    public class InsuranceKYC
    {
        [Key]
        public int ID { get; set; }
        public string INumber { get; set; }
        public string EmpName { get; set; }
        public string EmpDOB { get; set; }
        public string CitizenshipNo { get; set; }
        public string CitizenshipIssueDate { get; set; }
        public string FatherName { get; set; }
        public string FatherDOB { get; set; }
        public string MotherName { get; set; }
        public string MotherDOB { get; set; }
        public string PlanOption { get; set; }
        public string SpouseName { get; set; }
        public string SpouseDOB { get; set; }
        public string ChildNameA { get; set; }
        public string ChildNameB { get; set; }

        //public void GetKYCInput(int iNumber, string empName, string empDOB, string citizenshipNo, string citizenshipIssueDate, string fatherName, string fatherDOB, string motherName, string motherDOB, string planOption, string spouseName, string spouseDOB, string childNameA, string childNameB)
        //{

        //}
    }
}


