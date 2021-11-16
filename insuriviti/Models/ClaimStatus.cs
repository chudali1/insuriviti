using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace insuriviti.Models
{
    public class ClaimStatus
    {
       //open 
       // HR 
       // Forwarded
       //
       [Key]
       public int Id { get; set; }
        
       public string StatusName { get; set; }

       public int order { get; set; }
        
    }
}
