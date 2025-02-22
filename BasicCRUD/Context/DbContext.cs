﻿using BasicCRUD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrudApp.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}