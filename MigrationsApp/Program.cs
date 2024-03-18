using Microsoft.EntityFrameworkCore;
using YARSUWIKI.DOMAIN.Entity;

public class ApplicationContextCreator : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Author> Authors { get; set; }

    public ApplicationContextCreator()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb1;Username=postgres;Password=password");
    }
}

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Author> Authors { get; set; }

    public ApplicationContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb2;Username=postgres;Password=password");
    }
}

sealed class Program
{
    public static void Main(string[] args)
    {
        using (ApplicationContext db1 = new ApplicationContext())
        {
            var users = db1.Users.ToList();
            var authors = db1.Authors.ToList(); 
            using (ApplicationContext db2 = new ApplicationContext())
            {
                db2.Users.AddRange(users);
                db2.Authors.AddRange(authors);
                db2.SaveChanges();
            }
        }
    }
}