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
    public class signController : ControllerBase
    {
        private  ClientContext _context;
        private readonly IConfiguration _configuration;
        public signController(ClientContext context, IConfiguration configuration)
        {

            _context = context;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(Client request)
        {
            // Find the user in the database by email
            var user = await _context.Clients.FirstOrDefaultAsync(u => u.email == request.email && u.password == request.password);

            if (user == null)
            {
                return BadRequest("Invalid email or password.");
            }

            // Verify the password
            return Ok(CreateToken(user));

        }
        [HttpPost("loginphone")]
        public async Task<ActionResult<string>> Loginphone(string phone)
        {
            // Find the user in the database by email
            var user = await _context.Clients.FirstOrDefaultAsync(u => u.phonenumber == phone );

            if (user == null)
            {
                return BadRequest("Invalid email or password.");
            }

            // Verify the password
            return Ok(CreateToken(user));

        }
        private string CreateToken(Client client)
        {
            List<Claim> claims=new List<Claim>();
            if (client.phonenumber != null)
            {
                claims.Add(new Claim(ClaimTypes.MobilePhone, client.phonenumber));
        
            }else if (client.email != null)
            {
                claims.Add(new Claim(ClaimTypes.Email, client.email));
            }
            
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
        [HttpPost("register")]
        public async Task<ActionResult<Client>> register(Client client)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'ClientContext.Clients'  is null.");
            }
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return Ok(CreateToken(client));
        }
        [HttpPost("exist")]
        public async Task<ActionResult<bool>> exist(string phoneNumber)
        {
            if (_context.Clients == null)
            {
                return Ok(false);
            }

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.phonenumber == phoneNumber);

            if (client == null)
            {
                return Ok(false);
            }

            return Ok(true);
        }


    }
}
