using API.Migrations;
using Infrastructure.EfCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql("User ID=postgres;Password=dosaf08apjf2;Host=localhost;Port=5432;Database=gains;", builder =>
        builder.MigrationsAssembly(typeof(DesignTimeDbContextFactory).Assembly.FullName));
});

services.AddMediatR(typeof(MovesRequestHandler),
    typeof(MusclesRequestHandler),
    typeof(WeekRecosRequestHandler),
    typeof(ActivationDataRequestHandler));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    dbContext.Database.EnsureCreated();
    if (dbContext.Database.IsRelational())
        dbContext.Database.Migrate();

    dbContext.SaveChanges();
}

app.MapControllers();

app.Run();