using Microsoft.EntityFrameworkCore;

namespace WizardingBricks.Models;
public class AppDbContext : DbContext
{
    public DbSet<Set> Sets { get; set; }
    public DbSet<Series> Series { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}

