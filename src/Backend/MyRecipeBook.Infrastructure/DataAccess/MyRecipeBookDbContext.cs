﻿using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;

namespace MyRecipeBook.Infrastructure.DataAccess
{
    internal class MyRecipeBookDbContext : DbContext
    {
        public MyRecipeBookDbContext(DbContextOptions opt) : base(opt)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyRecipeBookDbContext).Assembly);
        }

    }
}
