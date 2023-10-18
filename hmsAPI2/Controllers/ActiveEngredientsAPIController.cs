using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hmsAPI2.Data;
using hmsAPI2.Models;

namespace hmsAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveEngredientsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActiveEngredientsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ActiveEngredientsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActiveEngredients>>> GetActiveEngredients()
        {
            return await _context.ActiveEngredients.ToListAsync();
        }

        // GET: api/ActiveEngredientsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActiveEngredients>> GetActiveEngredients(int id)
        {
            var activeEngredients = await _context.ActiveEngredients.FindAsync(id);

            if (activeEngredients == null)
            {
                return NotFound();
            }

            return activeEngredients;
        }

        // PUT: api/ActiveEngredientsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActiveEngredients(int id, ActiveEngredients activeEngredients)
        {
            if (id != activeEngredients.EngredientID)
            {
                return BadRequest();
            }

            _context.Entry(activeEngredients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActiveEngredientsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ActiveEngredientsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ActiveEngredients>> PostActiveEngredients(ActiveEngredients activeEngredients)
        {
            _context.ActiveEngredients.Add(activeEngredients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActiveEngredients", new { id = activeEngredients.EngredientID }, activeEngredients);
        }

        // DELETE: api/ActiveEngredientsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActiveEngredients>> DeleteActiveEngredients(int id)
        {
            var activeEngredients = await _context.ActiveEngredients.FindAsync(id);
            if (activeEngredients == null)
            {
                return NotFound();
            }

            _context.ActiveEngredients.Remove(activeEngredients);
            await _context.SaveChangesAsync();

            return activeEngredients;
        }

        private bool ActiveEngredientsExists(int id)
        {
            return _context.ActiveEngredients.Any(e => e.EngredientID == id);
        }
    }
}
