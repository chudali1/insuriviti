using insuriviti.Data;
using insuriviti.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace insuriviti.Controllers
{
    [Authorize(Roles = "HR, Admin, User")]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        //public HomeController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

               [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "HR, Admin, User")]
        public IActionResult Landing()
        {
            return View();
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Faq()
        {
            return View();
        }

        [Authorize(Roles = "HR, User")]
        public IActionResult ClaimHistory()
        {
            IEnumerable<ClaimHistory> claimHistories;
            if (User.IsInRole("HR")){
                claimHistories = _context.ClaimHistory;
                
            }
            else
            {
                claimHistories = _context.ClaimHistory.Where(x => x.LastUpdateUser == User.Identity.Name);
            }

            return View(claimHistories);
        }

        [Authorize(Roles = "HR, User")]
        public IActionResult ActiveClaims()
        {
            //IEnumerable<ClaimHistory> claimHistories;

            var activeClaims = _context.ClaimHistory.FromSqlRaw("select * from (select *, row_number() over(partition by claimid order by lastupdatedate desc ,id desc) as rn from claimHistory ch ) t where t.rn = 1 and  t.ClaimStatusID not in (4,6)");

            //if (User.IsInRole("HR"))
            //{
            //    claimHistories = _context.ClaimHistory.Where(x => x.ClaimStatusID == 1);
            //}
            //else
            //{
            //    claimHistories = _context.ClaimHistory.Where(x => x.LastUpdateUser == User.Identity.Name && x.ClaimStatusID ==1);
            //}

            return View(activeClaims);
        }

        [Authorize(Roles = "HR, User")]
        [HttpGet]
        public IActionResult ClaimSubmit()
        {
            return View();
        }


        [Authorize(Roles = "HR, User")]
        [HttpGet]
        public IActionResult ViewClaimSubmit(int Id)
        {
            var claimSubmit = _context.ClaimSubmit.Where(x => x.id == Id).FirstOrDefault();


            return View(claimSubmit);
          
        }

        [Authorize(Roles = "HR, User")]
        [HttpGet]
        public IActionResult EditClaimSubmit(int Id )
        {
            
           var  claimSubmit = _context.ClaimSubmit.Where(x => x.id == Id).FirstOrDefault();


            return View(claimSubmit);
        }

        [Authorize(Roles = "HR, User")]
        [HttpPost]
        public IActionResult EditClaimSubmit(ClaimSubmit claimSubmit)
        {
            if (!ModelState.IsValid)
            {
                return View(claimSubmit);

            }
            _context.ClaimSubmit.Update(claimSubmit);
            _context.SaveChanges();


            return RedirectToAction("ActiveClaims"); ;
        }

        [Authorize(Roles = "HR, User")]
        [HttpPost]
        public IActionResult ClaimSubmit(ClaimSubmit claimSubmit)
        {
            if(!ModelState.IsValid){
                return View(claimSubmit);

            }

            _context.ClaimSubmit.Add(claimSubmit);
            _context.SaveChanges();

            var claimHistory = new ClaimHistory {
                ClaimId = claimSubmit.id,
                EmployeeName = claimSubmit.FullName,
                ClaimStatusID = 1,
                FeedBack = "",
                CalimAmount = claimSubmit.TotalAmountClaimed.Value,
                ReinburshmentAmount = 0.0f,
                CreatedDate = claimSubmit.Date.Value,
                LastUpdateDate= DateTime.Now,
                LastUpdateUser = User.Identity.Name,
                PaidMonth = ""
                
                     
            
            };
                    
            _context.ClaimHistory.Add(claimHistory);
            _context.SaveChanges();
            return RedirectToAction("ClaimHistory");
        }


        //[Authorize(Roles = "HR")]
        //[HttpGet]
        //public IActionResult ProcessClaim()
        //{
        //    var processClaim = _context.ProcessClaim.FromSqlRaw("select * from (select *, row_number() over(partition by claimid order by lastupdatedate desc ,id desc) as rn from claimHistory ch ) t where t.rn = 1 and t.ClaimStatusID in (1,3,5)");



        //    return View(processClaim);
        //}



        [Authorize(Roles = "HR, Admin, User")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
