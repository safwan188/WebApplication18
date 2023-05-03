using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class optionContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public optionContext(DbContextOptions<optionContext> options)
           : base(options)
        {
        }

        public DbSet<option> optionlist { get; set; }
    }
}
