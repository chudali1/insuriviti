using insuriviti.Data;
using insuriviti.Models;
using insuriviti.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insuriviti.Controllers
{
    [Authorize(Roles = "HR")]
    public class ProcessClaimController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProcessClaimController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
              List<ClaimHistory> claims = _context.ClaimHistory
                .FromSqlRaw("" +
                    "select * " +
                    "from " +
                    "(select ch.* " +
                    ", row_number() over(partition by claimid order by lastupdatedate desc ,id desc) as rn " +
                    "from claimHistory ch ) t where t.rn = 1 and t.ClaimStatusID in (1,3,5)").ToList();

            List<ProcessClaim> claimsNeedToBeProcessed = new List<ProcessClaim>();

            foreach (var claim in claims)
            {
                claimsNeedToBeProcessed.Add(new ProcessClaim
                {
                    ClaimId = claim.ClaimId,
                    EmployeeName = claim.EmployeeName,
                    ClaimStatusID = claim.ClaimStatusID,
                    FeedBack = claim.FeedBack,
                    ClaimAmount = claim.CalimAmount,
                    ReinburshmentAmount = claim.ReinburshmentAmount,
                    CreatedDate = claim.CreatedDate,
                    LastUpdateDate = claim.LastUpdateDate,
                    LastUpdateUser = claim.LastUpdateUser,
                    PaidMonth = claim.PaidMonth,
                    ClaimStatusName = _context.ClaimStatus.Where(x => x.Id == claim.ClaimStatusID).Select(x => x.StatusName).SingleOrDefault()

                });
            } 


            return View(claimsNeedToBeProcessed);
        }

        [HttpGet]
        public IActionResult EditClaims(int id)
        {
            var data = _context.ClaimSubmit
                .Join(_context.ClaimHistory, o => o.id, h => h.ClaimId, (o, h) => new
                {
                    id = h.Id,
                    claimid = h.ClaimId,
                    EmployeeName = h.EmployeeName,
                    ClaimStatusName = _context.ClaimStatus.Where(x => x.Id == h.ClaimStatusID).Select(x => x.StatusName).SingleOrDefault(),
                    FeedBack = h.FeedBack,
                    ClaimAmount = h.CalimAmount,
                    ReinburshmentAmount = h.ReinburshmentAmount,
                    CreatedDate = h.CreatedDate,
                    LastUpdateDate = h.LastUpdateDate,
                    LastUpdateUser = h.LastUpdateUser,
                    PaidMonth = h.PaidMonth,

                    DateOfBirth = o.DateOfBirth,
                    PatientName = o.PatientName,
                    RelationWithPatient = o.RelationWithPatient,
                    GroupPolicyNo = o.GroupPolicyNo,
                    NatureOfSick = o.NatureOfSick,
                    BankName = o.BankName,
                    AccountNo = o.AccountNo,
                    MobileNo = o.MobileNo,


                    CoverageEffDate = o.CoverageEffDate,
                    NoOfTreatementPaperAttached = o.NoOfTreatementPaperAttached,
                    NoOfBillAttached = o.NoOfBillAttached,
                    TotalAmountClaimed = o.TotalAmountClaimed,
                    email = o.email,

                    DateTimeOfAccident = o.DateTimeOfAccident,
                    CompelledDate = o.CompelledDate,
                    ReturnToWorkDate = o.ReturnToWorkDate,

                    EmployeeRepresentativeName = o.EmployeeRepresentativeName,
                    date = o.Date
                })
                .Where(x => x.claimid == id)
                .OrderByDescending(x => x.LastUpdateDate)
                .OrderByDescending(x => x.id)
                .Take(1)
                .SingleOrDefault();

            ProcessClaim processClaim = new ProcessClaim
            {
                ProcessClaimsHistoryId = data.id,
                ClaimId = data.claimid,
                EmployeeName = data.EmployeeName,
                ClaimStatusName = data.ClaimStatusName,
                FeedBack = data.FeedBack,
                ClaimAmount = data.ClaimAmount,
                ReinburshmentAmount = data.ReinburshmentAmount,
                CreatedDate = data.CreatedDate,
                LastUpdateDate = data.LastUpdateDate,
                LastUpdateUser = data.LastUpdateUser,
                PaidMonth = data.PaidMonth,

                DateOfBirth = data.DateOfBirth,
                PatientName = data.PatientName,
                RelationWithPatient = data.RelationWithPatient,
                GroupPolicyNo = data.GroupPolicyNo,
                NatureOfSick = data.NatureOfSick,
                BankName = data.BankName,
                AccountNo = data.AccountNo,
                MobileNo = data.MobileNo,


                CoverageEffDate = data.CoverageEffDate,
                NoOfTreatementPaperAttached = data.NoOfTreatementPaperAttached,
                NoOfBillAttached = data.NoOfBillAttached,
                TotalAmountClaimed = data.TotalAmountClaimed,
                email = data.email,

                DateTimeOfAccident = data.DateTimeOfAccident,
                CompelledDate = data.CompelledDate,
                ReturnToWorkDate = data.ReturnToWorkDate,

                EmployeeRepresentativeName = data.EmployeeRepresentativeName,
                Date = data.date,
                ClaimStatus = _context.ClaimStatus.Select(x => x.StatusName ).ToList()
            };
                 
            return View(processClaim);
        }


        [HttpPost]
        public IActionResult SaveClaims(ProcessClaim processClaim)
        {
            if(!ModelState.IsValid)
            {
                return View("EditClaims", processClaim);
            }

            ClaimHistory claimHistory = new ClaimHistory
            {
                ClaimId = processClaim.ClaimId,
                EmployeeName = processClaim.EmployeeName,
                ClaimStatusID = _context.ClaimStatus.Where(x => x.StatusName == processClaim.ClaimStatusName).Select(x => x.Id).SingleOrDefault(),
                FeedBack = processClaim.FeedBack,
                CalimAmount = processClaim.ClaimAmount,
                ReinburshmentAmount = processClaim.ReinburshmentAmount,
                CreatedDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                LastUpdateUser = User.Identity.Name,
                PaidMonth = processClaim.PaidMonth
            };


            _context.ClaimHistory.Add(claimHistory);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
