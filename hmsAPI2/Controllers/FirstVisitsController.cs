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
    public class FirstVisitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FirstVisitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FirstVisits
        public async Task<IActionResult> Index()
        {
            return View(await _context.FirstVisit.ToListAsync());
        }

        // GET: FirstVisits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstVisit = await _context.FirstVisit
                .FirstOrDefaultAsync(m => m.VisitId == id);
            if (firstVisit == null)
            {
                return NotFound();
            }

            return View(firstVisit);
        }

        // GET: FirstVisits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FirstVisits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitId,ChronicHistory,DoctorNumber,CurrentChronicMedication,KnownAllegies")] FirstVisit firstVisit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firstVisit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(firstVisit);
        }

        // GET: FirstVisits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstVisit = await _context.FirstVisit.FindAsync(id);
            if (firstVisit == null)
            {
                return NotFound();
            }
            return View(firstVisit);
        }

        // POST: FirstVisits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitId,ChronicHistory,DoctorNumber,CurrentChronicMedication,KnownAllegies")] FirstVisit firstVisit)
        {
            if (id != firstVisit.VisitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firstVisit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirstVisitExists(firstVisit.VisitId))
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
            return View(firstVisit);
        }

        // GET: FirstVisits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstVisit = await _context.FirstVisit
                .FirstOrDefaultAsync(m => m.VisitId == id);
            if (firstVisit == null)
            {
                return NotFound();
            }

            return View(firstVisit);
        }

        // POST: FirstVisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firstVisit = await _context.FirstVisit.FindAsync(id);
            _context.FirstVisit.Remove(firstVisit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirstVisitExists(int id)
        {
            return _context.FirstVisit.Any(e => e.VisitId == id);
        }
    }
}
