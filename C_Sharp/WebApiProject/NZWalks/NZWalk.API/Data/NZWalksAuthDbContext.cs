using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalk.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* New Guid value of ID for reader Role  */
            string readerRoleId = "6510cab5-9654-45b6-9705-11803df00229";
            /* New Guid value of ID for write Role  */
            string writerRoleId = "4421c31c-304d-4495-b7f4-7a93809e5a00";

            /* Creating list of Identity Role */
            IEnumerable<IdentityRole> roles = new List<IdentityRole>()
            {
                /* Identity Role For Reader */
                new IdentityRole()
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },

                /* Identity Role For Reader */
                new IdentityRole()
                {
                    Id = writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
