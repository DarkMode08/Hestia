using AppLogin.Models;
using AppLogin.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AppLogin.Custom
{
    public class EncryptionHelper
    {
        // Funcion para poder acceder a la confi de appsettings.json
        private readonly IConfiguration _configuration;

        public EncryptionHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Funcion de Encriptado
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir la contraseña a bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Generar el hash
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convertir el hash a una cadena hexadecimal
                StringBuilder hash = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hash.Append(b.ToString("x2"));
                }

                return hash.ToString();
            }
        }

        public string TriggerJWT(_User modelo) {
            // Crear la info del usuario para el token
            var userClaim = new[]
            {
                // Metodo para la solicitud de autenticacion
                new Claim(ClaimTypes.NameIdentifier, modelo.id_User.ToString()),
                new Claim(ClaimTypes.Email, modelo.Email!)
            };

            // Codificacion de Llave
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Creacion del token
            var jwtConfig = new JwtSecurityToken(
                claims: userClaim,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: credentials
                );

            // Escribir el token
            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
