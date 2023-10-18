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
    public class FirstVisitsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FirstVisitsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FirstVisitsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FirstVisit>>> GetFirstVisit()
        {
            return await _context.FirstVisit.ToListAsync();
        }

        // GET: api/FirstVisitsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FirstVisit>> GetFirstVisit(int id)
        {
            var firstVisit = await _context.FirstVisit.FindAsync(id);

            if (firstVisit == null)
            {
                return NotFound();
            }

            return firstVisit;
        }

        // PUT: api/FirstVisitsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirstVisit(int id, FirstVisit firstVisit)
        {
            if (id != firstVisit.VisitId)
            {
                return BadRequest();
            }

            _context.Entry(firstVisit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirstVisitExists(id))
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

        // POST: api/FirstVisitsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FirstVisit>> PostFirstVisit(FirstVisit firstVisit)
        {
            _context.FirstVisit.Add(firstVisit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirstVisit", new { id = firstVisit.VisitId }, firstVisit);
        }

        // DELETE: api/FirstVisitsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FirstVisit>> DeleteFirstVisit(int id)
        {
            var firstVisit = await _context.FirstVisit.FindAsync(id);
            if (firstVisit == null)
            {
                return NotFound();
            }

            _context.FirstVisit.Remove(firstVisit);
            await _context.SaveChangesAsync();

            return firstVisit;
        }

        private bool FirstVisitExists(int id)
        {
            return _context.FirstVisit.Any(e => e.VisitId == id);
        }
    }
}
