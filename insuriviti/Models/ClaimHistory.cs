using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace insuriviti.Models
{
    public class ClaimHistory
    {
        [Key]
        public int Id { get; set; }

        public int ClaimId { get; set; }

        public string EmployeeName { get; set; }

        public int ClaimStatusID { get; set; }

        //navigation property
        public ClaimStatus ClaimStatus { get; set; }


        public string FeedBack { get; set; }

        public float CalimAmount { get; set; }

        public float? ReinburshmentAmount { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public String LastUpdateUser { get; set; }


    }
}
