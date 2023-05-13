using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class imageContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public imageContext(DbContextOptions<imageContext> options)
           : base(options)
        {
        }

        public DbSet<image> images { get; set; }
    }
}
