﻿using ExpenseTracker.Core.Categories;
using ExpenseTracker.Core.Expenses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Common.Persistence;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<CategoryItem> CategoryItems { get; set; }

    public DbSet<Expense> Expenses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.CategoryItems)
            .WithOne(c => c.Category)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CategoryItem>()
            .HasMany(i => i.Expenses)
            .WithOne(e => e.CategoryItem)
            .OnDelete(DeleteBehavior.Restrict);
 

    }
}
