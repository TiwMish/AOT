using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AOTBackend.Data;
using AOTBackend.Models;

namespace AOTBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PallindromesController : ControllerBase
    {
        private readonly AOTBackendContext _context;

        public PallindromesController(AOTBackendContext context)
        {
            _context = context;
        }

        // GET: api/Pallindromes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pallindrome>>> GetPallindrome()
        {
            return await _context.Pallindrome.ToListAsync();
        }

        // GET: api/Pallindromes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pallindrome>> GetPallindrome(string id)
        {
            var pallindrome = await _context.Pallindrome.FindAsync(id);

            if (pallindrome == null)
            {
                return NotFound();
            }

            return pallindrome;
        }

        // PUT: api/Pallindromes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPallindrome(string id, Pallindrome pallindrome)
        {
            if (id != pallindrome.QueryString)
            {
                return BadRequest();
            }

            _context.Entry(pallindrome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PallindromeExists(id))
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

        // POST: api/Pallindromes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pallindrome>> PostPallindrome(Pallindrome pallindrome)
        {
            _context.Pallindrome.Add(pallindrome);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PallindromeExists(pallindrome.QueryString))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPallindrome", new { id = pallindrome.QueryString }, pallindrome);
        }

        // DELETE: api/Pallindromes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePallindrome(string id)
        {
            var pallindrome = await _context.Pallindrome.FindAsync(id);
            if (pallindrome == null)
            {
                return NotFound();
            }

            _context.Pallindrome.Remove(pallindrome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PallindromeExists(string id)
        {
            return _context.Pallindrome.Any(e => e.QueryString == id);
        }
    }
}
