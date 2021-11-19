using insuriviti.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace insuriviti.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClaimSubmit> ClaimSubmit { get; set; }
        public DbSet<ClaimStatus> ClaimStatus { get; set; }
        public DbSet<ClaimHistory> ClaimHistory { get; set; }

        public DbSet<FileUpload> FileUpload { get; set; }




    }
}
