using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserServies, UserServies>();
builder.Services.AddScoped<IUserRepositroy, UserRepositroy>();
builder.Services.AddDbContext<Baby_Prudocts_webApi>(options=>options.UseSqlServer("Data Source=srv2/pupils;"));
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
