using insuriviti.Data;
using insuriviti.Models;
using insuriviti.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace insuriviti.Controllers
{
    [Authorize(Roles = "HR")]
    public class InsuranceClaimController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public InsuranceClaimController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var data2 = from ch in _context.ClaimHistory.ToList<ClaimHistory>()
                        group ch by ch.ClaimId
                            into groups
                        select groups.OrderByDescending(p => p.LastUpdateDate).OrderByDescending(x => x.Id).First();

            var data3 = data2
                    .Join(_context.ClaimSubmit, l => l.ClaimId, r => r.id, (l, r) => new {
                    id = l.Id,
                    claimid = l.ClaimId,
                    EmployeeName = l.EmployeeName,
                    ClaimStatusID = l.ClaimStatusID,
                    ClaimStatusName = _context.ClaimStatus.Where(x => x.Id == l.ClaimStatusID).Select(x => x.StatusName).SingleOrDefault(),
                    FeedBack = l.FeedBack,
                    ClaimAmount = l.CalimAmount,
                    ReinburshmentAmount = l.ReinburshmentAmount,
                    CreatedDate = l.CreatedDate,
                    LastUpdateDate = l.LastUpdateDate,
                    LastUpdateUser = l.LastUpdateUser,
                    PaidMonth = l.PaidMonth,

                    DateOfBirth = r.DateOfBirth,
                    PatientName = r.PatientName,
                    RelationWithPatient = r.RelationWithPatient,
                    GroupPolicyNo = r.GroupPolicyNo,
                    NatureOfSick = r.NatureOfSick,
                    BankName = r.BankName,
                    AccountNo = r.AccountNo,
                    MobileNo = r.MobileNo,


                    CoverageEffDate = r.CoverageEffDate,
                    NoOfTreatementPaperAttached = r.NoOfTreatementPaperAttached,
                    NoOfBillAttached = r.NoOfBillAttached,
                    TotalAmountClaimed = r.TotalAmountClaimed,
                    email = r.email,

                    DateTimeOfAccident = r.DateTimeOfAccident,
                    CompelledDate = r.CompelledDate,
                    ReturnToWorkDate = r.ReturnToWorkDate,

                    EmployeeRepresentativeName = r.EmployeeRepresentativeName,
                    date = r.Date
                }).Where(x => x.ClaimStatusID == 2)
                  .ToList();


            List<ProcessClaim> claims = new List<ProcessClaim>();

            foreach (var claim in data3)
            {
                claims.Add(new ProcessClaim
                {
                    ProcessClaimsHistoryId = claim.id,
                    ClaimId = claim.claimid,
                    EmployeeName = claim.EmployeeName,
                    ClaimStatusName = claim.ClaimStatusName,
                    FeedBack = claim.FeedBack,
                    ClaimAmount = claim.ClaimAmount,
                    ReinburshmentAmount = claim.ReinburshmentAmount,
                    CreatedDate = claim.CreatedDate,
                    LastUpdateDate = claim.LastUpdateDate,
                    LastUpdateUser = claim.LastUpdateUser,
                    PaidMonth = claim.PaidMonth,

                    DateOfBirth = claim.DateOfBirth,
                    PatientName = claim.PatientName,
                    RelationWithPatient = claim.RelationWithPatient,
                    GroupPolicyNo = claim.GroupPolicyNo,
                    NatureOfSick = claim.NatureOfSick,
                    BankName = claim.BankName,
                    AccountNo = claim.AccountNo,
                    MobileNo = claim.MobileNo,


                    CoverageEffDate = claim.CoverageEffDate,
                    NoOfTreatementPaperAttached = claim.NoOfTreatementPaperAttached,
                    NoOfBillAttached = claim.NoOfBillAttached,
                    TotalAmountClaimed = claim.TotalAmountClaimed,
                    email = claim.email,

                    DateTimeOfAccident = claim.DateTimeOfAccident,
                    CompelledDate = claim.CompelledDate,
                    ReturnToWorkDate = claim.ReturnToWorkDate,

                    EmployeeRepresentativeName = claim.EmployeeRepresentativeName,
                    Date = claim.date,
                    ClaimStatus = _context.ClaimStatus.Select(x => x.StatusName).ToList() //for drop down.
                }) ;
            }
            
            return View(claims);
        }

        [HttpGet]
        public IActionResult Edit(int id)
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
                ClaimStatus = _context.ClaimStatus.Select(x => x.StatusName).ToList()
            };

            return View(processClaim);
        }


        [HttpPost]
        public IActionResult SaveClaims(ProcessClaim processClaim)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", processClaim);
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
