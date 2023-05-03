using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication18.Data;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class homecatsController : ControllerBase
    {
        private readonly homecatContext _context;

        public homecatsController(homecatContext context)
        {
            _context = context;
        }

        // GET: api/homecats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<homecat>>> Gethomecats()
        {
          if (_context.homecats == null)
          {
              return NotFound();
          }
            return await _context.homecats.ToListAsync();
        }

        // GET: api/homecats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<homecat>> Gethomecat(int id)
        {
          if (_context.homecats == null)
          {
              return NotFound();
          }
            var homecat = await _context.homecats.FindAsync(id);

            if (homecat == null)
            {
                return NotFound();
            }

            return homecat;
        }

        // PUT: api/homecats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthomecat(int id, homecat homecat)
        {
            if (id != homecat.id)
            {
                return BadRequest();
            }

            _context.Entry(homecat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!homecatExists(id))
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

        // POST: api/homecats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<homecat>> Posthomecat(homecat homecat)
        {
          if (_context.homecats == null)
          {
              return Problem("Entity set 'homecatContext.homecats'  is null.");
          }
            _context.homecats.Add(homecat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethomecat", new { id = homecat.id }, homecat);
        }

        // DELETE: api/homecats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehomecat(int id)
        {
            if (_context.homecats == null)
            {
                return NotFound();
            }
            var homecat = await _context.homecats.FindAsync(id);
            if (homecat == null)
            {
                return NotFound();
            }

            _context.homecats.Remove(homecat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool homecatExists(int id)
        {
            return (_context.homecats?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
