using Infrastructure.EfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EfCore;

public class AppDbContext : DbContext
{
    public DbSet<EfMove> Moves { get; set; } = null!;
    public DbSet<EfMuscle> Muscles { get; set; } = null!;
    public DbSet<EfMuscleConnection> MuscleConnections { get; set; } = null!;
    public DbSet<EfMuscleActivationData> MuscleActivationData { get; set; } = null!;

    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EfMoveConfiguration());
        modelBuilder.ApplyConfiguration(new EfMuscleConfiguration());
        modelBuilder.ApplyConfiguration(new EfMuscleConnectionConfiguration());
        modelBuilder.ApplyConfiguration(new EfMuscleActivationDataConfiguration());
    }
}