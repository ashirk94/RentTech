using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentTech.Migrations
{
    public partial class Reviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f471b24e-7a7b-4430-802d-88f2729ba71f", "c2e93785-0ca0-43ef-a54e-e77a73603717" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c8395367-b9f1-4f70-935b-28593eae7a84", "4c4a15d0-df1d-4ff4-a05c-63710274a51f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "308d6f5f-82ae-4fc3-aecf-49a3001cc113", "cf8b39ee-b264-4e0b-805a-8c0491e552bb" });
        }
    }
}
