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
    public class InteractionsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InteractionsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InteractionsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interactions>>> GetInteractions()
        {
            return await _context.Interactions.ToListAsync();
        }

        // GET: api/InteractionsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interactions>> GetInteractions(int id)
        {
            var interactions = await _context.Interactions.FindAsync(id);

            if (interactions == null)
            {
                return NotFound();
            }

            return interactions;
        }

        // PUT: api/InteractionsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInteractions(int id, Interactions interactions)
        {
            if (id != interactions.InteractionID)
            {
                return BadRequest();
            }

            _context.Entry(interactions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InteractionsExists(id))
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

        // POST: api/InteractionsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Interactions>> PostInteractions(Interactions interactions)
        {
            _context.Interactions.Add(interactions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInteractions", new { id = interactions.InteractionID }, interactions);
        }

        // DELETE: api/InteractionsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interactions>> DeleteInteractions(int id)
        {
            var interactions = await _context.Interactions.FindAsync(id);
            if (interactions == null)
            {
                return NotFound();
            }

            _context.Interactions.Remove(interactions);
            await _context.SaveChangesAsync();

            return interactions;
        }

        private bool InteractionsExists(int id)
        {
            return _context.Interactions.Any(e => e.InteractionID == id);
        }
    }
}
