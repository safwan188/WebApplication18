using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class homecatContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public homecatContext(DbContextOptions<homecatContext> options)
           : base(options)
        {
        }

        public DbSet<homecat> homecats { get; set; }
    }
}
