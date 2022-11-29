﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
