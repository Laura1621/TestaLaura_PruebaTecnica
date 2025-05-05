using Microsoft.EntityFrameworkCore;
using prueba_tecnica_laura.Data;
using prueba_tecnica_laura.Servicios;
using AutoMapper;
using prueba_tecnica_laura.Mappeo;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Agregamos los controlladores a los servicios
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Aca pasamos la conexcion a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Los servicios que usamos
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//FluentValidation
builder.Services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblyContaining<Program>();
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();