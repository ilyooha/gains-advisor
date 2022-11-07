using Infrastructure.EfCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("app"); });

services.AddMediatR(typeof(MovesRequestHandler),
    typeof(MuscleGroupsRequestHandler),
    typeof(WeekRecosRequestHandler));

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