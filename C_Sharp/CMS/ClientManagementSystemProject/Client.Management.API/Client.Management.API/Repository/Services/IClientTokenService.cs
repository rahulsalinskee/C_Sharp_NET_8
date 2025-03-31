using Microsoft.AspNetCore.Identity;

namespace Client.Management.API.Repository.Services
{
    public interface IClientTokenService
    {
        public string GenerateToken(IdentityUser identityUser, IEnumerable<string> roles);
    }
}
