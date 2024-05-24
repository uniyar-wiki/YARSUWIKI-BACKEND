using Microsoft.EntityFrameworkCore;
using YARSU.Server.Models;

namespace YARSU.Server.Services;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=yarsuwiki.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the many-to-many relationship
        modelBuilder.Entity<User>(); // Specify the name of the join table if desired

        modelBuilder.Entity<Page>().HasMany(c => c.Comments);

        modelBuilder.Entity<Comment>().HasOne(c => c.User);
    }
}

