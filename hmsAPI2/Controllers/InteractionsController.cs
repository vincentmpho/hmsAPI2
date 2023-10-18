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
    public class InteractionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InteractionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Interactions.ToListAsync());
        }

        // GET: Interactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interactions = await _context.Interactions
                .FirstOrDefaultAsync(m => m.InteractionID == id);
            if (interactions == null)
            {
                return NotFound();
            }

            return View(interactions);
        }

        // GET: Interactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Interactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InteractionID,Name,With")] Interactions interactions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interactions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interactions);
        }

        // GET: Interactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interactions = await _context.Interactions.FindAsync(id);
            if (interactions == null)
            {
                return NotFound();
            }
            return View(interactions);
        }

        // POST: Interactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InteractionID,Name,With")] Interactions interactions)
        {
            if (id != interactions.InteractionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interactions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InteractionsExists(interactions.InteractionID))
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
            return View(interactions);
        }

        // GET: Interactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interactions = await _context.Interactions
                .FirstOrDefaultAsync(m => m.InteractionID == id);
            if (interactions == null)
            {
                return NotFound();
            }

            return View(interactions);
        }

        // POST: Interactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interactions = await _context.Interactions.FindAsync(id);
            _context.Interactions.Remove(interactions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InteractionsExists(int id)
        {
            return _context.Interactions.Any(e => e.InteractionID == id);
        }
    }
}
