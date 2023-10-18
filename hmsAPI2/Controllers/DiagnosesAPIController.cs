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
    public class DiagnosesAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DiagnosesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DiagnosesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diagnosis>>> GetDiagnosis()
        {
            return await _context.Diagnosis.ToListAsync();
        }

        // GET: api/DiagnosesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diagnosis>> GetDiagnosis(string id)
        {
            var diagnosis = await _context.Diagnosis.FindAsync(id);

            if (diagnosis == null)
            {
                return NotFound();
            }

            return diagnosis;
        }

        // PUT: api/DiagnosesAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnosis(string id, Diagnosis diagnosis)
        {
            if (id != diagnosis.ICD10_code)
            {
                return BadRequest();
            }

            _context.Entry(diagnosis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosisExists(id))
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

        // POST: api/DiagnosesAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Diagnosis>> PostDiagnosis(Diagnosis diagnosis)
        {
            _context.Diagnosis.Add(diagnosis);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DiagnosisExists(diagnosis.ICD10_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDiagnosis", new { id = diagnosis.ICD10_code }, diagnosis);
        }

        // DELETE: api/DiagnosesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Diagnosis>> DeleteDiagnosis(string id)
        {
            var diagnosis = await _context.Diagnosis.FindAsync(id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            _context.Diagnosis.Remove(diagnosis);
            await _context.SaveChangesAsync();

            return diagnosis;
        }

        private bool DiagnosisExists(string id)
        {
            return _context.Diagnosis.Any(e => e.ICD10_code == id);
        }
    }
}
