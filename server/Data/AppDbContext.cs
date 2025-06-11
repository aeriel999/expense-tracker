using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<CategoryItem> CategoryItems { get; set; }

    public DbSet<Expense> Expenses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
