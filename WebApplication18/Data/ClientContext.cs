using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class ClientContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options)
           : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
    }
}
