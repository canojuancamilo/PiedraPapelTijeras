using BackendPiendraPapelTijeras.Core.Repository;
using BackendPiendraPapelTijeras.Core.Service;
using FrontendPiedraPapelTijera.Interfaces;
using FrontendPiedraPapelTijera.Repositories;
using FrontendPiedraPapelTijera.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IPiedraPapelTijeraService, PiedraPapelTijeraService>();
builder.Services.AddScoped<IPiedraPapelTijeraRepository, PiedraPapelTijeraRepository>();
builder.Services.AddScoped<IManejoErrorRepository, ManejoErroresRepository>();
builder.Services.AddScoped<IManejoErrorService, ManejoErroresService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
