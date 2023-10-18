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
    public class MedicalPracticesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicalPracticesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicalPractices
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalPractice.ToListAsync());
        }

        // GET: MedicalPractices/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalPractice = await _context.MedicalPractice
                .FirstOrDefaultAsync(m => m.PracticeNumber == id);
            if (medicalPractice == null)
            {
                return NotFound();
            }

            return View(medicalPractice);
        }

        // GET: MedicalPractices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalPractices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PracticeNumber,Contact,Name,Address,Email")] MedicalPractice medicalPractice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalPractice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalPractice);
        }

        // GET: MedicalPractices/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalPractice = await _context.MedicalPractice.FindAsync(id);
            if (medicalPractice == null)
            {
                return NotFound();
            }
            return View(medicalPractice);
        }

        // POST: MedicalPractices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PracticeNumber,Contact,Name,Address,Email")] MedicalPractice medicalPractice)
        {
            if (id != medicalPractice.PracticeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalPractice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalPracticeExists(medicalPractice.PracticeNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicalPractice);
        }

        // GET: MedicalPractices/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalPractice = await _context.MedicalPractice
                .FirstOrDefaultAsync(m => m.PracticeNumber == id);
            if (medicalPractice == null)
            {
                return NotFound();
            }

            return View(medicalPractice);
        }

        // POST: MedicalPractices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medicalPractice = await _context.MedicalPractice.FindAsync(id);
            _context.MedicalPractice.Remove(medicalPractice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalPracticeExists(string id)
        {
            return _context.MedicalPractice.Any(e => e.PracticeNumber == id);
        }
    }
}
