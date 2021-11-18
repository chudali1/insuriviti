using insuriviti.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace insuriviti.ViewModel
{
    public class ProcessClaim
    {
        
        public int Id { get; set; }

        [Display(Name = "Claim ID")]
        public int ClaimId { get; set; }

        [Display(Name = "Full Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Claim Status")]
        public int ClaimStatusID { get; set; }


        [Display(Name = "Feedback")]
        public string FeedBack { get; set; }

        [Display(Name = "Claim Amount")]
        public float ClaimAmount { get; set; }

        [Display(Name = "Reinburshment Amount")]
        public float? ReinburshmentAmount { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Last Update Date")]
        public DateTime LastUpdateDate { get; set; }

        [Display(Name = "Last Update User")]
        public String LastUpdateUser { get; set; }

        [Display(Name = "Paid Month")]
        public String PaidMonth { get; set; }

        public string ClaimStatusName { get; set; }


        //claim submit
        public List<string> ClaimStatus { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Patient Name")]
        public String PatientName { get; set; }

        [Display(Name = "Realtionship With Employee")]
        public String RelationWithPatient { get; set; }

        [Display(Name = "Group Policy No")]
        public int GroupPolicyNo { get; set; }


        [Display(Name = "Nature Of Sickness/Accident")]
        public String NatureOfSick { get; set; }


        [Display(Name = "Bank Name")]
        public String BankName { get; set; }


        [Display(Name = "Account No")]
        public String AccountNo { get; set; }


        [Display(Name = "Mobile No")]
        public String MobileNo { get; set; }

        [Display(Name = "Coverage Effective Date")]
        public DateTime? CoverageEffDate { get; set; }

        [Display(Name = "No Of Treatement Paper Attached")]
        public int NoOfTreatementPaperAttached { get; set; }

        [Display(Name = "No Of Bill Attached")]
        public int NoOfBillAttached { get; set; }

        [Display(Name = "Total Amount Claimed")]
        public float? TotalAmountClaimed { get; set; }

        [Display(Name = "Employee Email")]
        public string email { get; set; }

        //only for accident

        [Display(Name = "Date Of Accident")]
        public DateTime? DateTimeOfAccident { get; set; }

        [Display(Name = "When was insured compelled to give up his/her duties? ")]

        public DateTime? CompelledDate { get; set; }

        [Display(Name = "When did insured returned to work?")]

        public DateTime? ReturnToWorkDate { get; set; }


        [Display(Name = "  Employer’s Representative Name:")]
        public String EmployeeRepresentativeName { get; set; }

        public DateTime? Date { get; set; }

    }
}
