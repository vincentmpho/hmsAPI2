using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hmsAPI2.Data;
using hmsAPI2.Models;

namespace hmsAPI2.Controllers
{
    public class ContentsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ContentsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Contents
        public async Task<IActionResult> Index()
        {
            var displaydata = db.patient.Tolist();
            return View(displaydata);
        }


        [HttpGet]

        public async Task<IActionResult> Index(string patientsearch)

        {
            ViewData["GetPatientsdetails"] = patientsearch;

            var Patientsaquery = from x in _db.Patient select x;

            if (!string.IsNullOrEmpty(patientsearch))
            {
                Patientsaquery = Patientsaquery.Where(x => x.PatientID.Contains(patientsearch));
            }

            return View(await Patientsaquery.AsNoTracking().ToListAsync());
        }



        public IActionResult create()

        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> create(int id)
        {

            if (ModelState.IsValid)
            {
                _db.Add(id);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
    