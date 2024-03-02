using Microsoft.EntityFrameworkCore;
using YARSUWIKI.DOMAIN.Entity;
using YARSUWIKI.DOMAIN.Utils;

namespace YARSUWIKI.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Author> Author { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.ToTable("Users").HasKey(x => x.Id);

            builder.HasData(new User[]
            {
                new User()
                {
                    Id = 1,
                    Email = "n.sergievskij@uniyar.ac.ru",
                    Password = Hasher.PasswordHash("123456")
                },
                new User()
                {
                    Id = 2,
                    Email = "s.krylov@uniyar.ac.ru",
                    Password = Hasher.PasswordHash("654321"),
                }
            });

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
        });
    }

}