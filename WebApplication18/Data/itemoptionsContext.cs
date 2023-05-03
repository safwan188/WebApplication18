using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class itemoptionsContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public itemoptionsContext(DbContextOptions<itemoptionsContext> options)
           : base(options)
        {
        }
        
        public DbSet<itemoptions> itemoptions { get; set; }
    }
}
