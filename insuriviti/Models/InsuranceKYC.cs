using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace insuriviti.Models
{
    public class InsuranceKYC
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar(10)")]
        public string INumber { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string EmpName { get; set; }

        [Column(TypeName="Date")]
        public DateTime? EmpDOB { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string CitizenshipNo { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? CitizenshipIssueDate { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string FatherName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? FatherDOB { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string MotherName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? MotherDOB { get; set; }

        public int PlanOption { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string SpouseName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? SpouseDOB { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string ChildNameA { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string ChildNameB { get; set; }
    }
}


