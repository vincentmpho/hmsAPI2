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
    public class PhamacistsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PhamacistsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PhamacistsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phamacist>>> GetPhamacist()
        {
            return await _context.Phamacist.ToListAsync();
        }

        // GET: api/PhamacistsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phamacist>> GetPhamacist(int id)
        {
            var phamacist = await _context.Phamacist.FindAsync(id);

            if (phamacist == null)
            {
                return NotFound();
            }

            return phamacist;
        }

        // PUT: api/PhamacistsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhamacist(int id, Phamacist phamacist)
        {
            if (id != phamacist.PhamacistNumber)
            {
                return BadRequest();
            }

            _context.Entry(phamacist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhamacistExists(id))
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

        // POST: api/PhamacistsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Phamacist>> PostPhamacist(Phamacist phamacist)
        {
            _context.Phamacist.Add(phamacist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhamacist", new { id = phamacist.PhamacistNumber }, phamacist);
        }

        // DELETE: api/PhamacistsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Phamacist>> DeletePhamacist(int id)
        {
            var phamacist = await _context.Phamacist.FindAsync(id);
            if (phamacist == null)
            {
                return NotFound();
            }

            _context.Phamacist.Remove(phamacist);
            await _context.SaveChangesAsync();

            return phamacist;
        }

        private bool PhamacistExists(int id)
        {
            return _context.Phamacist.Any(e => e.PhamacistNumber == id);
        }
    }
}
