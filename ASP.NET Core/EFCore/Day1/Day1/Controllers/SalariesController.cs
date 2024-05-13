using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day1;
using Day1.Model;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly CompanyDBContext _context;

        public SalariesController(CompanyDBContext context)
        {
            _context = context;
        }

        // GET: api/Salaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salaries>>> GetSalaries()
        {
            return await _context.Salaries.ToListAsync();
        }

        // GET: api/Salaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salaries>> GetSalaries(int id)
        {
            var salaries = await _context.Salaries.FindAsync(id);

            if (salaries == null)
            {
                return NotFound();
            }

            return salaries;
        }

        // PUT: api/Salaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaries(int id, Salaries salaries)
        {
            if (id != salaries.Id)
            {
                return BadRequest();
            }

            _context.Entry(salaries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalariesExists(id))
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

        // POST: api/Salaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salaries>> PostSalaries(Salaries salaries)
        {
            _context.Salaries.Add(salaries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalaries", new { id = salaries.Id }, salaries);
        }

        // DELETE: api/Salaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaries(int id)
        {
            var salaries = await _context.Salaries.FindAsync(id);
            if (salaries == null)
            {
                return NotFound();
            }

            _context.Salaries.Remove(salaries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalariesExists(int id)
        {
            return _context.Salaries.Any(e => e.Id == id);
        }
    }
}
