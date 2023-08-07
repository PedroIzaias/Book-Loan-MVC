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

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }

            LoansModel loan = _db.Loans.FirstOrDefault(x => x.Id == id);

            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }
        
        [HttpPost]
        public IActionResult Register(LoansModel loans) 
        {
            if (ModelState.IsValid) 
            {
                _db.Loans.Add(loans);
                _db.SaveChanges();

                TempData["SuccessMessage"] = "Registration completed successfully!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(LoansModel loan)
        {
            if (ModelState.IsValid)
            {
                _db.Loans.Update(loan);
                _db.SaveChanges();

                TempData["SuccessMessage"] = "Editing done successfully!";

                return RedirectToAction("Index");
            }

            return View(loan);
        }

        [HttpGet]
        public IActionResult Delete(int? id) 
        { 
            if (id == null || id == 0) 
            {
                return NotFound();
            }

            LoansModel loan = _db.Loans.FirstOrDefault(x => x.Id == id);

            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        [HttpPost]
        public IActionResult Delete(LoansModel loan)
        {
            if (loan == null)
            {
                return NotFound();
            }

            _db.Loans.Remove(loan);
            _db.SaveChanges();

            TempData["SuccessMessage"] = "Deletion successful!";

            return RedirectToAction("Index");
        }
    }
}