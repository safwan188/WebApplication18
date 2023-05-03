using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class clientorderContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public clientorderContext(DbContextOptions<clientorderContext> options)
           : base(options)
        {

        }

        public DbSet<clientorder> clientorders { get; set; }
    }
}
