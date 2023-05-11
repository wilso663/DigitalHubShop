﻿using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }
    }

}
