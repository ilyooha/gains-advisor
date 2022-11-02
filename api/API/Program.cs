using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddDbContext<AppDbContext>(options => { options.UseInMemoryDatabase("app"); });

services.AddMediatR(typeof(MovesRequestHandler));

var app = builder.Build();

app.MapControllers();

app.Run();