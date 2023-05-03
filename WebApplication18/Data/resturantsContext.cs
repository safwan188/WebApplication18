using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class resturantsContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public resturantsContext(DbContextOptions<resturantsContext> options)
           : base(options)
        {
        }

        public DbSet<resturants> resturants { get; set; }

        public DbSet<WebApplication18.Models.categorie>? categorie { get; set; }
        public DbSet<WebApplication18.Models.menu_item>? menu_item { get; set; }
        public DbSet<WebApplication18.Models.itemoptions>? itemoptions { get; set; }
        public DbSet<WebApplication18.Models.option>? option { get; set; }
        
    }
}
