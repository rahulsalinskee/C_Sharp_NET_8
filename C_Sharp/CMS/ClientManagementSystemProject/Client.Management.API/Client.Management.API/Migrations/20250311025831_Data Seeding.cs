using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Client.Management.API.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("102271b1-17d5-49f4-b130-3947a0d1362e"), "123 Main St, Anytown, OR", "doe@hotmail.com", "John", "Doe", "1234567890" },
                    { new Guid("6182c353-919d-45ce-8c02-3574cad9c79e"), "789 Pine Ln, Othertown", "david.lee@hotmail.com", "David", "Lee", "5551234567" },
                    { new Guid("72820816-59b9-4da9-a255-7e2dbfc07486"), "707 Spruce Grv, Up", "ashley.martinez@hotmail.com", "Ashley", "Martinez", "3034045050" },
                    { new Guid("76ee3690-1855-40ff-a5a0-42960f6b55d7"), "606 Willow Blvd, There", "brian.rodriguez@example.com", "Brian", "Rodriguez", "9098087070" },
                    { new Guid("da1361ad-d2a1-462f-baaf-2251d7dabe5d"), "303 Birch Ct, Somewhere", "emily.davis@hotmail.com", "Emily", "Davis", "7778889999" },
                    { new Guid("e076e2d0-7803-4dd8-9230-3174e333d670"), "505 Redwood Way, Here", "jessica.garcia@hotmail.com", "Jessica", "Garcia", "6067078080" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: new Guid("102271b1-17d5-49f4-b130-3947a0d1362e"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: new Guid("6182c353-919d-45ce-8c02-3574cad9c79e"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: new Guid("72820816-59b9-4da9-a255-7e2dbfc07486"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: new Guid("76ee3690-1855-40ff-a5a0-42960f6b55d7"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: new Guid("da1361ad-d2a1-462f-baaf-2251d7dabe5d"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: new Guid("e076e2d0-7803-4dd8-9230-3174e333d670"));
        }
    }
}
