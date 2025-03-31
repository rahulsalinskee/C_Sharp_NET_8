using Microsoft.AspNetCore.Identity;

namespace NZWalk.API.Repositories.Interfaces
{
    public interface ITokenService
    {
        public string CreateJwtToken(IdentityUser identityUser, IEnumerable<string> roles);
    }
}
