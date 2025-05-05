using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserServies, UserServies>();
builder.Services.AddScoped<IUserRepositroy, UserRepositroy>();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
