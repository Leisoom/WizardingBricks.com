using Microsoft.EntityFrameworkCore;

namespace WizardingBricks.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Set> Sets { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Minifigure> Minifigures { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}

