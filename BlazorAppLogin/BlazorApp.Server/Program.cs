// Definicion de Caracteristicas de La App

// Referencias para la conectividad
using Microsoft.EntityFrameworkCore; // Framework Instalado y en uso
using BlazorApp.Server.Models;
using BlazorApp.Server.Data;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Llamado de la cadena de conexion con el DBContext
builder.Services.AddDbContext<DbloginContext>(_Options =>
{
    _Options.UseSqlServer(builder.Configuration.GetConnectionString("StringConection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()  // Permitir cualquier origen
                   .AllowAnyMethod()  // Permitir cualquier método
                   .AllowAnyHeader(); // Permitir cualquier encabezado
        });
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(_Options =>
{
    _Options.LoginPath = "/Access/Login";
    _Options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
});


// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

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