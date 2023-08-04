using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookLoans.Models;
using BookLoans.Data;

namespace BookLoans.Controllers
{
    public class LoanController : Controller
    {
        readonly private ApplicationDbContext _db;
        public LoanController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<LoansModel> loans = _db.Loans;
            return View(loans);
        }

        public IActionResult Register() 
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(LoansModel loans) 
        {
            if (ModelState.IsValid) 
            {
                _db.Loans.Add(loans);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}