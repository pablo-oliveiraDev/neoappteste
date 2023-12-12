using csharp_docker_postgree_api.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace csharp_docker_postgree_api.Repository
{
    public class AuthRepository : IAuthRepository
    {
        public string GerarTokenJwt(dynamic user, string userType)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.CPF.ToString()),
                new Claim(ClaimTypes.Name, user.Password),
                new Claim("UserType", userType) // Adicione a reivindicação para o tipo de usuário

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chave_secreta_super_segura123456"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                null,
                null,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
