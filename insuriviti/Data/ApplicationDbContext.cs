using insuriviti.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using insuriviti.ViewModel;

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
        //public DbSet<insuriviti.ViewModel.ProcessClaim> ProcessClaim { get; set; }
        public DbSet<InsuranceKYC> InsuranceKYC { get; set; }


    }
}
