using BackendPiendraPapelTijeras.Context;
using BackendPiendraPapelTijeras.Core.Interface.Repositories;
using BackendPiendraPapelTijeras.Core.Interface.Services;
using BackendPiendraPapelTijeras.Core.Repository;
using BackendPiendraPapelTijeras.Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IPiedraPapelTijeraService, PiedraPapelTijeraService>();
builder.Services.AddScoped<IPiedraPapelTijeraRepository, PiedraPapelTijeraRepository>();
builder.Services.AddScoped<IManejoErroresRepository, ManejoErroresRepository>();
builder.Services.AddScoped<IManejoErroresService, ManejoErroresService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API piedra papel o tijeras", Version = "v1" });
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
