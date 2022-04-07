using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Entities;
using ProductManagementAPI.Middleware;
using ProductManagementAPI.Models;
using ProductManagementAPI.Models.Validators;
using ProductManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<ProductManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductManagementDbConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ProductManagementDbSeeder>();
builder.Services.AddScoped<IValidator<NewProductDto>, NewProductDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateProductDto>, UpdateProductDtoValidator>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

var app = builder.Build();


// Configure the HTTP request pipeline.
SeedDatabase();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();


void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetRequiredService<ProductManagementDbSeeder>();
        seeder.Seed();
    }
}