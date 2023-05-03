﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WebApplication18.Models;
namespace WebApplication18.Data
{
    public class food_orderContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public food_orderContext(DbContextOptions<food_orderContext> options)
           : base(options)
        {
        }

        public DbSet<food_order> food_orders { get; set; }
    }
}
