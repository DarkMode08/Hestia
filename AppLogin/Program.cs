// Definicion de Caracteristicas de La App

// Referencias para la conectividad
using Microsoft.EntityFrameworkCore; // Framework Instalado y en uso
using AppLogin.Models;
using AppLogin.Data;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Llamado de la cadena de conexion con el DBContext
builder.Services.AddDbContext<AppDBContext>(_Options =>
    {
        _Options.UseSqlServer(builder.Configuration.GetConnectionString("StringConection"));
    });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(_Options =>
{
    _Options.LoginPath = "/Access/Login";
    
    _Options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
