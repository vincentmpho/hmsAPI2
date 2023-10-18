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
    public class PhamacistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhamacistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Phamacists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Phamacist.ToListAsync());
        }

        // GET: Phamacists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phamacist = await _context.Phamacist
                .FirstOrDefaultAsync(m => m.PhamacistNumber == id);
            if (phamacist == null)
            {
                return NotFound();
            }

            return View(phamacist);
        }

        // GET: Phamacists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phamacists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhamacistNumber,PhamacistName,PhamacistSurname,PhamacistContact,PhamacistEmail,PhamacistRegistrationNumber,Phamacy")] Phamacist phamacist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phamacist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phamacist);
        }

        // GET: Phamacists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phamacist = await _context.Phamacist.FindAsync(id);
            if (phamacist == null)
            {
                return NotFound();
            }
            return View(phamacist);
        }

        // POST: Phamacists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhamacistNumber,PhamacistName,PhamacistSurname,PhamacistContact,PhamacistEmail,PhamacistRegistrationNumber,Phamacy")] Phamacist phamacist)
        {
            if (id != phamacist.PhamacistNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phamacist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhamacistExists(phamacist.PhamacistNumber))
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
            return View(phamacist);
        }

        // GET: Phamacists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phamacist = await _context.Phamacist
                .FirstOrDefaultAsync(m => m.PhamacistNumber == id);
            if (phamacist == null)
            {
                return NotFound();
            }

            return View(phamacist);
        }

        // POST: Phamacists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phamacist = await _context.Phamacist.FindAsync(id);
            _context.Phamacist.Remove(phamacist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhamacistExists(int id)
        {
            return _context.Phamacist.Any(e => e.PhamacistNumber == id);
        }
    }
}
