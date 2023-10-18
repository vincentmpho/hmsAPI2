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
    public class ActiveEngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActiveEngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActiveEngredients
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActiveEngredients.ToListAsync());
        }

        // GET: ActiveEngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeEngredients = await _context.ActiveEngredients
                .FirstOrDefaultAsync(m => m.EngredientID == id);
            if (activeEngredients == null)
            {
                return NotFound();
            }

            return View(activeEngredients);
        }

        // GET: ActiveEngredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActiveEngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EngredientID,EngredientName")] ActiveEngredients activeEngredients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activeEngredients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activeEngredients);
        }

        // GET: ActiveEngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeEngredients = await _context.ActiveEngredients.FindAsync(id);
            if (activeEngredients == null)
            {
                return NotFound();
            }
            return View(activeEngredients);
        }

        // POST: ActiveEngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EngredientID,EngredientName")] ActiveEngredients activeEngredients)
        {
            if (id != activeEngredients.EngredientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeEngredients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiveEngredientsExists(activeEngredients.EngredientID))
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
            return View(activeEngredients);
        }

        // GET: ActiveEngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeEngredients = await _context.ActiveEngredients
                .FirstOrDefaultAsync(m => m.EngredientID == id);
            if (activeEngredients == null)
            {
                return NotFound();
            }

            return View(activeEngredients);
        }

        // POST: ActiveEngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activeEngredients = await _context.ActiveEngredients.FindAsync(id);
            _context.ActiveEngredients.Remove(activeEngredients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiveEngredientsExists(int id)
        {
            return _context.ActiveEngredients.Any(e => e.EngredientID == id);
        }
    }
}
