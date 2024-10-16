using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Server;
using BlazorApp.Share;
using BlazorApp.Server.Data;
using BlazorApp.Server.Models;
using Microsoft.Win32;
using System.Runtime.ConstrainedExecution;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : Controller
    {
        // Agregar una Variable unicamente para la lectura
        private readonly AppDBContext _dbContext;

        // Este constructor es para recibir el DBContext - DataBase
        public AccessController(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // 
        [HttpPost]
        public async Task<IActionResult> Register(_UserViewModels model)
        {

            // Metodo utilizado para comparar los password a la hora de hacer el registro
            if (model.Password != model.Confirm_Password)
            {
                ViewData["Menssage"] = "Passwords do not match";
                return View(model);
            }

            // Metodo para agregar un usuario
            _User user = new _User()
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
                // No necesita el ConfimPass por que con el if anterior se valida si los 2 password coinciden
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            if (user.id_User != 0)
            {
                return RedirectToAction("Login", "Access");
            }

            ViewData["Message"] = "Error Registering";
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            _User? UserLocated = await _dbContext.Users.Where(u =>
                                                                u.Email == model.Email &&
                                                                u.Password == model.Password
                                                                ).FirstOrDefaultAsync();

            if (UserLocated == null)
            {
                ViewData["Message"] = "User not Located";
                return View(model);
            }

            // Guardar la informacion del usuario
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, UserLocated.Name)
            };

            // Uso de la autenticacion al guardar los datos
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                // Refresca la sesion del Usuario
                AllowRefresh = true
            };

            // Inicializa la Autenticacion y guarda la data del usuario dentro de la autenticacion de Cookie
            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    properties
                );

            return RedirectToAction("Index", "Home");
        }
    }
}
