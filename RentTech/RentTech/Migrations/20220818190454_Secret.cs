using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentTech.Migrations
{
    public partial class Secret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "08e4cd6f-d229-41b2-b945-25bfd317cec0", "52cbc701-1743-4368-972e-3c5d594e901d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0c06c43c-9d31-49e2-aa62-9bd2791a756a", "c9d815d5-f4fb-4c48-abcf-1b0235685f1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9609f172-2ae2-4deb-8a0e-fca81aac74ac", "f106a4b8-1f90-4e5b-b598-75c2eab6ad9c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
