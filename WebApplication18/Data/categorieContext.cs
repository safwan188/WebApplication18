using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class categorieContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public categorieContext(DbContextOptions<categorieContext> options)
           : base(options)
        {
        }

        public DbSet<categorie> categorie { get; set; }
    }
}
