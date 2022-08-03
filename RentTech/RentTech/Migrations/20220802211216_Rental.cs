using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentTech.Migrations
{
    public partial class Rental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eefa6b6e-e3dc-483b-bf2b-3fce7f28373b", "2e221cc5-bf91-4d7a-86f1-b1d1d281d2b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "11fdc195-2544-4d3c-b9d8-e7d89fbd1e30", "e6dc2c1a-19c5-42f9-a1c8-47a62be2d84d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e0022606-6845-4d6c-b348-e6bb0dae96a9", "53f4748b-1197-496f-90f0-83f60a668aa8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b425b78b-0db1-43d5-b5b6-31b9a48bfd17", "d06ab6f2-f47a-49a2-9635-ce391c25406f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b3791f8-409d-42b7-8840-641ffa06a903", "75515cde-87c7-421a-a0be-1e2cd1987142" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "048e9643-1cb3-44e6-a9a0-8d4ee26aec3b", "97279f73-4ed3-4e2d-b2ae-d66a975fa88b" });
        }
    }
}
