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
    public class ContraIndicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContraIndicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContraIndications
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContraIndication.ToListAsync());
        }

        // GET: ContraIndications/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contraIndication = await _context.ContraIndication
                .FirstOrDefaultAsync(m => m.ICD10_code == id);
            if (contraIndication == null)
            {
                return NotFound();
            }

            return View(contraIndication);
        }

        // GET: ContraIndications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContraIndications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ICD10_code,ActiveEngredients,Diagnosis")] ContraIndication contraIndication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contraIndication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contraIndication);
        }

        // GET: ContraIndications/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contraIndication = await _context.ContraIndication.FindAsync(id);
            if (contraIndication == null)
            {
                return NotFound();
            }
            return View(contraIndication);
        }

        // POST: ContraIndications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ICD10_code,ActiveEngredients,Diagnosis")] ContraIndication contraIndication)
        {
            if (id != contraIndication.ICD10_code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contraIndication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContraIndicationExists(contraIndication.ICD10_code))
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
            return View(contraIndication);
        }

        // GET: ContraIndications/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contraIndication = await _context.ContraIndication
                .FirstOrDefaultAsync(m => m.ICD10_code == id);
            if (contraIndication == null)
            {
                return NotFound();
            }

            return View(contraIndication);
        }

        // POST: ContraIndications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var contraIndication = await _context.ContraIndication.FindAsync(id);
            _context.ContraIndication.Remove(contraIndication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContraIndicationExists(string id)
        {
            return _context.ContraIndication.Any(e => e.ICD10_code == id);
        }
    }
}
