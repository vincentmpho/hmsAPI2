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
    public class ContraIndicationsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContraIndicationsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ContraIndicationsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContraIndication>>> GetContraIndication()
        {
            return await _context.ContraIndication.ToListAsync();
        }

        // GET: api/ContraIndicationsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContraIndication>> GetContraIndication(string id)
        {
            var contraIndication = await _context.ContraIndication.FindAsync(id);

            if (contraIndication == null)
            {
                return NotFound();
            }

            return contraIndication;
        }

        // PUT: api/ContraIndicationsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContraIndication(string id, ContraIndication contraIndication)
        {
            if (id != contraIndication.ICD10_code)
            {
                return BadRequest();
            }

            _context.Entry(contraIndication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContraIndicationExists(id))
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

        // POST: api/ContraIndicationsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContraIndication>> PostContraIndication(ContraIndication contraIndication)
        {
            _context.ContraIndication.Add(contraIndication);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContraIndicationExists(contraIndication.ICD10_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContraIndication", new { id = contraIndication.ICD10_code }, contraIndication);
        }

        // DELETE: api/ContraIndicationsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContraIndication>> DeleteContraIndication(string id)
        {
            var contraIndication = await _context.ContraIndication.FindAsync(id);
            if (contraIndication == null)
            {
                return NotFound();
            }

            _context.ContraIndication.Remove(contraIndication);
            await _context.SaveChangesAsync();

            return contraIndication;
        }

        private bool ContraIndicationExists(string id)
        {
            return _context.ContraIndication.Any(e => e.ICD10_code == id);
        }
    }
}
