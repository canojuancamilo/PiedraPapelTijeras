using BackendPiendraPapelTijeras.Context;
using BackendPiendraPapelTijeras.Core.Interface.Repositories;
using BackendPiendraPapelTijeras.Core.Interface.Services;
using BackendPiendraPapelTijeras.Core.Repository;
using BackendPiendraPapelTijeras.Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IPiedraPapelTijeraService, PiedraPapelTijeraService>();
builder.Services.AddScoped<IPiedraPapelTijeraRepository, PiedraPapelTijeraRepository>();
builder.Services.AddScoped<IManejoErroresRepository, ManejoErroresRepository>();
builder.Services.AddScoped<IManejoErroresService, ManejoErroresService>();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<AplicationBdContext>(m =>
m.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
