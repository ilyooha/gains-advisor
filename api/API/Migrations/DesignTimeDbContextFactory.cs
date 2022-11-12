using Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Migrations;

// ReSharper disable once UnusedType.Global
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql("User ID=postgres;Password=dosaf08apjf2;Host=localhost;Port=5432;Database=gains;", builder =>
                builder.MigrationsAssembly(typeof(DesignTimeDbContextFactory).Assembly.FullName));

        return new AppDbContext(builder.Options);
    }
}