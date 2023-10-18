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
    public class MedicationsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedicationsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicationsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetMedication()
        {
            return await _context.Medication.ToListAsync();
        }

        // GET: api/MedicationsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetMedication(string id)
        {
            var medication = await _context.Medication.FindAsync(id);

            if (medication == null)
            {
                return NotFound();
            }

            return medication;
        }

        // PUT: api/MedicationsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedication(string id, Medication medication)
        {
            if (id != medication.MedicationNumber)
            {
                return BadRequest();
            }

            _context.Entry(medication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationExists(id))
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

        // POST: api/MedicationsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Medication>> PostMedication(Medication medication)
        {
            _context.Medication.Add(medication);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicationExists(medication.MedicationNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedication", new { id = medication.MedicationNumber }, medication);
        }

        // DELETE: api/MedicationsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medication>> DeleteMedication(string id)
        {
            var medication = await _context.Medication.FindAsync(id);
            if (medication == null)
            {
                return NotFound();
            }

            _context.Medication.Remove(medication);
            await _context.SaveChangesAsync();

            return medication;
        }

        private bool MedicationExists(string id)
        {
            return _context.Medication.Any(e => e.MedicationNumber == id);
        }
    }
}
