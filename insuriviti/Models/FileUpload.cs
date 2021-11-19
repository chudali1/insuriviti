using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace insuriviti.Models
{
    public class FileUpload
    {
        [Key]
        public int Id { get; set; }

        public int ClaimId { get; set; }

        public string fileName { get; set; }
    }
}
