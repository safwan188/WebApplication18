using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication18.Data;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class resturantsController : ControllerBase
    {
        private readonly resturantsContext _context;
        private readonly IConfiguration _configuration;
        public resturantsController(IConfiguration configuration,resturantsContext context)
        {
            _configuration= configuration;
            _context = context;
        }

        private string CreateToken(string client)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,client),

            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
        // GET: api/resturants
        [Route("/hi/{user}")]
        [HttpGet]
        public async Task<ActionResult<string>> Getresturants(string user)
        {
            return CreateToken(user);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<resturants>>> Getresturants()
        {
            if (_context.resturants == null)
            {
                return NotFound();
            }
            var resturants = await _context.resturants.ToListAsync();
            foreach (resturants e in resturants)
            {
                List<categorie> categories = _context.categorie.Where(o => o.resturantsid == e.id).ToList();
                foreach (categorie j in categories)
                {
                    List<menu_item> itms = _context.menu_item.Where(o => o.categorieid == j.id).ToList();
                    foreach (menu_item k in itms)
                    {
                        List<itemoptions> itemop = _context.itemoptions.Where(o => o.menu_itemid == k.id).ToList();
                        foreach (itemoptions p in itemop)
                        {
                            List<option> ops = _context.option.Where(o => o.itemoptionsid == p.id).ToList();
                            p.options = ops;


                        }
                        k.itemoptions = itemop;
                    }
                    j.items = itms;
                }
                e.categorie = categories;
            }
            return await _context.resturants.ToListAsync();
        }
        // GET: api/resturants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<resturants>> Getresturants(int id)
        {
          if (_context.resturants == null)
          {
              return NotFound();
          }
            var resturants = await _context.resturants.FindAsync(id);

            if (resturants == null)
            {
                return NotFound();
            }
            List<categorie> categories = _context.categorie.Where(o => o.resturantsid == resturants.id).ToList();
            foreach (categorie j in categories)
            {
                List<menu_item> itms = _context.menu_item.Where(o => o.categorieid == j.id).ToList();
                foreach (menu_item k in itms)
                {
                    List<itemoptions> itemop = _context.itemoptions.Where(o => o.menu_itemid == k.id).ToList();
                    foreach (itemoptions p in itemop)
                    {
                        List<option> ops = _context.option.Where(o => o.itemoptionsid == p.id).ToList();
                        p.options = ops;


                    }
                    k.itemoptions = itemop;
                }
                j.items = itms;
            }
            resturants.categorie = categories;

            return resturants;
        }

        // PUT: api/resturants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putresturants(int id, resturants resturants)
        {
            if (id != resturants.id)
            {
                return BadRequest();
            }

            _context.Entry(resturants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!resturantsExists(id))
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

        // POST: api/resturants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<resturants>> Postresturants(resturants resturants)
        {
          if (_context.resturants == null)
          {
              return Problem("Entity set 'resturantsContext.resturants'  is null.");
          }
            _context.resturants.Add(resturants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getresturants", new { id = resturants.id }, resturants);
        }

        // DELETE: api/resturants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteresturants(int id)
        {
            if (_context.resturants == null)
            {
                return NotFound();
            }
            var resturants = await _context.resturants.FindAsync(id);
            if (resturants == null)
            {
                return NotFound();
            }

            _context.resturants.Remove(resturants);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool resturantsExists(int id)
        {
            return (_context.resturants?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
