using Microsoft.EntityFrameworkCore;
using YARSUWIKI.DOMAIN.Entity;

namespace YARSUWIKI.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Author> Author { get; set; }
    
}