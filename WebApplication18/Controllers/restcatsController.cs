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
    public class restcatsController : ControllerBase
    {
        private readonly restcatContext _context;

        public restcatsController(restcatContext context)
        {
            _context = context;
        }

        // GET: api/restcats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<restcat>>> Getrestcats()
        {
          if (_context.restcats == null)
          {
              return NotFound();
          }
            return await _context.restcats.ToListAsync();
        }

        // GET: api/restcats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<restcat>> Getrestcat(int id)
        {
          if (_context.restcats == null)
          {
              return NotFound();
          }
            var restcat = await _context.restcats.FindAsync(id);

            if (restcat == null)
            {
                return NotFound();
            }

            return restcat;
        }

        // PUT: api/restcats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrestcat(int id, restcat restcat)
        {
            if (id != restcat.id)
            {
                return BadRequest();
            }

            _context.Entry(restcat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!restcatExists(id))
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

        // POST: api/restcats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<restcat>> Postrestcat(restcat restcat)
        {
          if (_context.restcats == null)
          {
              return Problem("Entity set 'restcatContext.restcats'  is null.");
          }
            _context.restcats.Add(restcat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrestcat", new { id = restcat.id }, restcat);
        }

        // DELETE: api/restcats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterestcat(int id)
        {
            if (_context.restcats == null)
            {
                return NotFound();
            }
            var restcat = await _context.restcats.FindAsync(id);
            if (restcat == null)
            {
                return NotFound();
            }

            _context.restcats.Remove(restcat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool restcatExists(int id)
        {
            return (_context.restcats?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
