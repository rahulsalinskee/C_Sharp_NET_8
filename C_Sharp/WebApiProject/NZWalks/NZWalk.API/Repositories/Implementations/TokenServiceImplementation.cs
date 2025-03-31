using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NZWalk.API.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalk.API.Repositories.Implementations
{
    public class TokenServiceImplementation : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenServiceImplementation(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string CreateJwtToken(IdentityUser identityUser, IEnumerable<string> roles)
        {
            /* Step 1: Create some claims from roles and other information for these tokens, to use these claims later */
            IList<Claim> claims = new List<Claim>();
            claims.Add(item: new Claim(type: ClaimTypes.Email, value: identityUser.Email));

            /* Iterating role from roles */
            foreach (var role in roles)
            {
                /* Step 2: Inside the roles collection we want to add claims */
                claims.Add(item: new Claim(type: ClaimTypes.Role, value: role));
            }

            /* Step 3: Need to get Key from App Settings JSON */
            var key = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(this._configuration["JWT:SecreteKey"]));

            /* Step 4: Need the above key along with security algorithm to create credentials */
            var credentials = new SigningCredentials(key: key, algorithm: SecurityAlgorithms.HmacSha256);

            /* Step 5: Create New Token with the above credential, Issuer, Audience,  */
            var token = new JwtSecurityToken
                (
                    issuer: _configuration["JWT:Issuer"], 
                    audience: _configuration["JWT:Audience"], 
                    claims: claims, 
                    expires: DateTime.Now.AddMinutes(15), 
                    signingCredentials: credentials
                );

            /* Step 6: Return Statement For New JWT Token Handler and write JWT token in string */
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
