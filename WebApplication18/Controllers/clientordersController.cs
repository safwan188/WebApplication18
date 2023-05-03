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
    public class clientordersController : ControllerBase
    {
        private readonly clientorderContext _context;

        public clientordersController(clientorderContext context)
        {
            _context = context;
        }

        // GET: api/clientorders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<clientorder>>> Getclientorders()
        {
          if (_context.clientorders == null)
          {
              return NotFound();
          }
            return await _context.clientorders.ToListAsync();
        }

        // GET: api/clientorders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<clientorder>> Getclientorder(int id)
        {
          if (_context.clientorders == null)
          {
              return NotFound();
          }
            var clientorder = await _context.clientorders.FindAsync(id);

            if (clientorder == null)
            {
                return NotFound();
            }

            return clientorder;
        }

        // PUT: api/clientorders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclientorder(int id, clientorder clientorder)
        {
            if (id != clientorder.id)
            {
                return BadRequest();
            }

            _context.Entry(clientorder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientorderExists(id))
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

        // POST: api/clientorders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<clientorder>> Postclientorder(clientorder clientorder)
        {
          if (_context.clientorders == null)
          {
              return Problem("Entity set 'clientorderContext.clientorders'  is null.");
          }
            _context.clientorders.Add(clientorder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getclientorder", new { id = clientorder.id }, clientorder);
        }

        // DELETE: api/clientorders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclientorder(int id)
        {
            if (_context.clientorders == null)
            {
                return NotFound();
            }
            var clientorder = await _context.clientorders.FindAsync(id);
            if (clientorder == null)
            {
                return NotFound();
            }

            _context.clientorders.Remove(clientorder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clientorderExists(int id)
        {
            return (_context.clientorders?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
