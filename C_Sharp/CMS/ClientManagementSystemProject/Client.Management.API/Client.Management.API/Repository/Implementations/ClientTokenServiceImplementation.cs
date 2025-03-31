using Client.Management.API.Repository.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Client.Management.API.Repository.Implementations
{
    public class ClientTokenServiceImplementation : IClientTokenService
    {
        private readonly IConfiguration _configuration;

        public ClientTokenServiceImplementation(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GenerateToken(IdentityUser identityUser, IEnumerable<string> roles)
        {
            IList<Claim> claims = new List<Claim>();
            claims.Add(item: new Claim(type: ClaimTypes.Email, value: identityUser.Email));

            foreach (var role in roles)
            {
                claims.Add(item: new Claim(type: ClaimTypes.Role, value: role));
            }

            var key = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(s: this._configuration["JWT:SecreteKey"]));

            var credentials = new SigningCredentials(key: key, algorithm: SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken
            (
                issuer: this._configuration["JWT:Issuer"],
                audience: this._configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(value: 30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token: jwtSecurityToken);
        }
    }
}
