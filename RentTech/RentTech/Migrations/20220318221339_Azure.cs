using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentTech.Migrations
{
    public partial class Azure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62c0ebb0-f734-4897-8228-9646663f9430", "2f52275b-d5c3-4df2-a0e6-5d3187314336" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b0c57d73-4a4f-45e2-9ff6-89fcda927c74", "a1838cc6-aa55-4a79-8590-a2b2de30f645" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f3ac2cd3-cbbf-4699-b521-b612e70b19b0", "6401c725-9870-4805-a46f-131151ae4fdb" });
        }
    }
}
