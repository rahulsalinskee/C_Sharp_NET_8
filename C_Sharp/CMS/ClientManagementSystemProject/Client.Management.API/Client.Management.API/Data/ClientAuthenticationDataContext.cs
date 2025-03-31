using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Client.Management.API.Data
{
    public class ClientAuthenticationDataContext : IdentityDbContext
    {
        public ClientAuthenticationDataContext(DbContextOptions<ClientAuthenticationDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string nonAdministratorId = "63ae1574-e6f0-4b04-ab5d-05f9b75a6f28";
            string administratorId = "f151ecc8-8e7f-49dd-b551-af4ba280ed22";

            IEnumerable<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = administratorId,
                    Name = "Admin",
                    NormalizedName = "Administrator".ToUpper(),
                    ConcurrencyStamp = administratorId
                },

                new IdentityRole()
                {
                    Id = nonAdministratorId,
                    Name = "NonAdministrator",
                    NormalizedName = "Non_Administrator".ToUpper(),
                    ConcurrencyStamp = nonAdministratorId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
