using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserServies, UserServies>();
builder.Services.AddScoped<IUserRepositroy, UserRepositroy>();
builder.Services.AddScoped<ICategoryServies, CategoryServies>();
builder.Services.AddScoped<ICategoryRepositroy, CategoryRepositroy>();
builder.Services.AddScoped<IProductServies, ProductServies>();
builder.Services.AddScoped<IProductRepositroy, ProductRepositroy>();
builder.Services.AddScoped<IOrderServies, OrderServies>();
builder.Services.AddScoped<IOrderRepositroy, OrderRepositroy>();
builder.Services.AddDbContext<Prudoct_Kategory_webApi>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Host.UseNLog();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
