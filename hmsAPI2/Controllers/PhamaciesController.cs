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
    public class PhamaciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhamaciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Phamacies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Phamacy.ToListAsync());
        }

        // GET: Phamacies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phamacy = await _context.Phamacy
                .FirstOrDefaultAsync(m => m.PhamacyName == id);
            if (phamacy == null)
            {
                return NotFound();
            }

            return View(phamacy);
        }

        // GET: Phamacies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phamacies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhamacyName,Address,ContactNumber,EmailAddress,LicenceNumber,ResponsiblePharmacist")] Phamacy phamacy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phamacy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phamacy);
        }

        // GET: Phamacies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phamacy = await _context.Phamacy.FindAsync(id);
            if (phamacy == null)
            {
                return NotFound();
            }
            return View(phamacy);
        }

        // POST: Phamacies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PhamacyName,Address,ContactNumber,EmailAddress,LicenceNumber,ResponsiblePharmacist")] Phamacy phamacy)
        {
            if (id != phamacy.PhamacyName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phamacy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhamacyExists(phamacy.PhamacyName))
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
            return View(phamacy);
        }

        // GET: Phamacies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phamacy = await _context.Phamacy
                .FirstOrDefaultAsync(m => m.PhamacyName == id);
            if (phamacy == null)
            {
                return NotFound();
            }

            return View(phamacy);
        }

        // POST: Phamacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phamacy = await _context.Phamacy.FindAsync(id);
            _context.Phamacy.Remove(phamacy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhamacyExists(string id)
        {
            return _context.Phamacy.Any(e => e.PhamacyName == id);
        }
    }
}
