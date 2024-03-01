using Microsoft.EntityFrameworkCore;
using VehiculoPrueba;
using VehiculoPrueba.Core.Interfaces;
using VehiculoPrueba.Core.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<ILocalidadService, LocalidadService>();
builder.Services.AddScoped<IRentaService, RentaService>();
builder.Services.AddTransient<ITestService, TestService>();
var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerUI();

app.Run();
