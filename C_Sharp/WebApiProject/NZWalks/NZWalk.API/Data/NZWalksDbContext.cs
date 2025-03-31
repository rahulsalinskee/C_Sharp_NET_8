using Microsoft.EntityFrameworkCore;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        /// <summary>
        /// Data Seeding
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Model / Table Name: Difficulty
            * Difficulties are of - Easy, Medium, Hard 
            * Create a list of difficulties for Easy, Medium, Hard
            */
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    /* We cannot use Guid.NewGuid() as every time it will generate a new Guid */
                    Id = Guid.Parse("193e03c0-ae9b-4e94-8e4e-bf9c607f98e6"),
                    Name = "Easy",
                },
                new Difficulty()
                {
                    /* We cannot use Guid.NewGuid() as every time it will generate a new Guid */
                    Id = Guid.Parse("114a8f02-1239-4d3f-ad47-204ba6f4b587"),
                    Name = "Medium",
                },
                new Difficulty()
                {
                    /* We cannot use Guid.NewGuid() as every time it will generate a new Guid */
                    Id = Guid.Parse("4a4bd671-c01f-40d7-8845-72e33128cb89"),
                    Name = "Hard"
                }
            };

            /* This line will seed data to database */
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            /* Model / Table Name: Region 
            * Create a list of Region
            */
            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            /* This line will seed data to database */
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
