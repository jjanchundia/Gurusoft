using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Gurosoft.Application.Utils
{
    //Capa o clase para logica de Usuarios
    public class LogicUsuarios
    {
        private readonly IConfiguration _config;
        public LogicUsuarios(IConfiguration config)
        {
            _config = config;
        }

        public string Token(string username, string password)
        {
            // Crear claims basados en el usuario autenticado
            var claims = new[]
            {
                    new Claim(username, password),
                    // Puedes agregar más claims según sea necesario (por ejemplo, roles)
                };

            // Configurar la clave secreta para firmar el token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddHours(24);
            // Configurar la información del token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expiracion,
                signingCredentials: creds);

            // Devolver el token JWT como resultado de la autenticación exitosa
            //return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            string token2 = new JwtSecurityTokenHandler().WriteToken(token).ToString();

            return token2;
        }
    }
}