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

        //navigation property
        


        [Display(Name = "Feedback")]
        public string FeedBack { get; set; }

        [Display(Name = "Claim Amount")]
        public float CalimAmount { get; set; }

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
    }
}
