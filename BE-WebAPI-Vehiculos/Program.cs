using BE_WebAPI_Vehiculos.Repository.Entities;
using BE_WebAPI_Vehiculos.Services.Interfaces;
using BE_WebAPI_Vehiculos.Services;
using BE_WebAPI_Vehiculos.Repository.Interfaces;
using BE_WebAPI_Vehiculos.Repository;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<BdvehiculosContext>();
builder.Services.AddSingleton<IVehiculoServices, VehiculoServices>();
builder.Services.AddSingleton<IVehiculoRepository, VehiculoRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
