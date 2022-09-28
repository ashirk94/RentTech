using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentTech.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "250dc72c-9af3-4477-8f28-08d534551a69", "642daf13-62cd-4d32-abdd-9106d12a58ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7eb6422e-ce66-4810-b79d-d846be622828", "c26d77ad-90a2-4e6c-9dc7-4d24e104feb5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "42157d82-f8e8-47be-8724-429b4ee8eec6", "c85dbb60-3f0e-4540-9bb7-056e533529c1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
