using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class menu_itemContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public menu_itemContext(DbContextOptions<menu_itemContext> options)
           : base(options)
        {
        }

        public DbSet<menu_item> menu_Item { get; set; }

        public DbSet<WebApplication18.Models.itemoptions>? itemoptions { get; set; }
    }
}
