using Client.Management.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Client.Management.API.Data
{
    public class ClientDataContext : DbContext
    {
        public ClientDataContext(DbContextOptions<ClientDataContext> options) : base(options)
        {
        }

        public DbSet<Models.Client> Clients { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var clients = new List<Models.Client>()
            {
                new Models.Client()
                {
                    ID = Guid.Parse("102271b1-17d5-49f4-b130-3947a0d1362e"),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "doe@hotmail.com",
                    Phone = "1234567890",
                    Address = "123 Main St, Anytown, OR",
                },
                new Models.Client()
                {
                    ID = Guid.Parse("76ee3690-1855-40ff-a5a0-42960f6b55d7"),
                    FirstName = "Brian",
                    LastName = "Rodriguez",
                    Email = "brian.rodriguez@example.com",
                    Phone = "9098087070",
                    Address = "606 Willow Blvd, There",
                },
                new Models.Client()
                {
                    ID = Guid.Parse("72820816-59b9-4da9-a255-7e2dbfc07486"),
                    FirstName = "Ashley",
                    LastName = "Martinez",
                    Email = "ashley.martinez@hotmail.com",
                    Phone = "3034045050",
                    Address = "707 Spruce Grv, Up",
                },
                new Models.Client()
                {
                    ID = Guid.Parse("e076e2d0-7803-4dd8-9230-3174e333d670"),
                    FirstName = "Jessica",
                    LastName = "Garcia",
                    Email = "jessica.garcia@hotmail.com",
                    Phone = "6067078080",
                    Address = "505 Redwood Way, Here",
                },
                new Models.Client()
                {
                    ID = Guid.Parse("da1361ad-d2a1-462f-baaf-2251d7dabe5d"),
                    FirstName = "Emily",
                    LastName = "Davis",
                    Email = "emily.davis@hotmail.com",
                    Phone = "7778889999",
                    Address = "303 Birch Ct, Somewhere",
                },
                new Models.Client()
                {
                    ID = Guid.Parse("6182c353-919d-45ce-8c02-3574cad9c79e"),
                    FirstName = "David",
                    LastName = "Lee",
                    Email = "david.lee@hotmail.com",
                    Phone = "5551234567",
                    Address = "789 Pine Ln, Othertown",
                },
            };

            modelBuilder.Entity<Models.Client>().HasData(clients);
        }
    }
}
