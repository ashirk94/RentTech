using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentTech.Data.Migrations
{
    public partial class Owner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechItem_AspNetUsers_AppUserId",
                table: "TechItem");

            migrationBuilder.DropIndex(
                name: "IX_TechItem_AppUserId",
                table: "TechItem");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TechItem");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "TechItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a183a6b-1f77-44c4-b7dd-e1ef0805935a", "df9ebfd5-c6e6-4ce2-a8b1-72cdbd6a627c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "42680b4b-f0f4-4cee-9de2-85b42c73b940", "1019bf67-4064-4994-984e-02aed773d5ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "90e6b375-d72f-4b12-a32d-4653663d34d6", "1326926e-964f-4c1b-b34f-cfbda965dc26" });

            migrationBuilder.CreateIndex(
                name: "IX_TechItem_OwnerId",
                table: "TechItem",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TechItem_AspNetUsers_OwnerId",
                table: "TechItem",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechItem_AspNetUsers_OwnerId",
                table: "TechItem");

            migrationBuilder.DropIndex(
                name: "IX_TechItem_OwnerId",
                table: "TechItem");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "TechItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "TechItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4624d70b-d2b0-4f91-9138-eeb6f5c0fd6f", "550a0e0e-516b-4bc8-9433-b53e3b6054a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "317766f5-0fa7-4b8f-93fc-45381e2abb8e", "3b78446b-dbf9-46d1-9ee2-febb80098000" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4c3a2fc2-419b-4e15-a8ef-faba6c4bf58d", "bbfcd876-ad59-4efe-9017-df1e133bc919" });

            migrationBuilder.CreateIndex(
                name: "IX_TechItem_AppUserId",
                table: "TechItem",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TechItem_AspNetUsers_AppUserId",
                table: "TechItem",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
