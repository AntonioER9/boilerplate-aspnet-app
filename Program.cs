using Microsoft.EntityFrameworkCore;
using Models;
using DTOs;
using FluentValidation;
using Validators;
using Services;
using Repository;
using Automappers;

var builder = WebApplication.CreateBuilder(args);

//Services
// builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddKeyedScoped<ICommonService<ProductDto, ProductInsertDto, ProductUpdateDto>, ProductService>("productService");

//Repository
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

// Entity Framework
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

// Validators
builder.Services.AddScoped<IValidator<ProductInsertDto>, ProductInsertValidator>();
builder.Services.AddScoped<IValidator<ProductUpdateDto>, ProductUpdateValidator>();

//Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();