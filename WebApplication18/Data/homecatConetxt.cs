using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class restcatContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public restcatContext(DbContextOptions<restcatContext> options)
           : base(options)
        {
        }

        public DbSet<restcat> restcats { get; set; }
    }
}
