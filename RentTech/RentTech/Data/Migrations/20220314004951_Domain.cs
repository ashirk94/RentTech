using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentTech.Data.Migrations
{
    public partial class Domain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReputationScore",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TechItem",
                columns: table => new
                {
                    TechItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechItem", x => x.TechItemId);
                    table.ForeignKey(
                        name: "FK_TechItem_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TechItemId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Review_TechItem_TechItemId",
                        column: x => x.TechItemId,
                        principalTable: "TechItem",
                        principalColumn: "TechItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechItemId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tag_TechItem_TechItemId",
                        column: x => x.TechItemId,
                        principalTable: "TechItem",
                        principalColumn: "TechItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "ReputationScore", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[,]
                {
                    { "A", 0, "4624d70b-d2b0-4f91-9138-eeb6f5c0fd6f", "AppUser", null, false, "Alan", "Shirk", false, null, null, null, null, null, false, null, 50, "550a0e0e-516b-4bc8-9433-b53e3b6054a3", false, null, "ashirk99" },
                    { "B", 0, "317766f5-0fa7-4b8f-93fc-45381e2abb8e", "AppUser", null, false, "Solaire", "ofAstora", false, null, null, null, null, null, false, null, 50, "3b78446b-dbf9-46d1-9ee2-febb80098000", false, null, "PraisetheSun" },
                    { "C", 0, "4c3a2fc2-419b-4e15-a8ef-faba6c4bf58d", "AppUser", null, false, "Lautrec", "ofCarim", false, null, null, null, null, null, false, null, 50, "bbfcd876-ad59-4efe-9017-df1e133bc919", false, null, "ShotelMan" }
                });

            migrationBuilder.InsertData(
                table: "TechItem",
                columns: new[] { "TechItemId", "AppUserId", "Condition", "Description", "IsRented", "OwnerId", "Price", "RentDate", "ReturnDate", "Thumbnail", "Title", "Type" },
                values: new object[,]
                {
                    { 1, null, "Good", null, false, "A", 75.989999999999995, null, null, null, "ASUS Laptop", "Laptop Computer" },
                    { 2, null, "Fair", null, false, "B", 50.0, null, null, null, "IPad", "Tablet" },
                    { 3, null, "Like-New", null, false, "C", 100.0, null, null, null, "PlayStation 5", "Game Console" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewerId",
                table: "Review",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_TechItemId",
                table: "Review",
                column: "TechItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TechItemId",
                table: "Tag",
                column: "TechItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TechItem_AppUserId",
                table: "TechItem",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "TechItem");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReputationScore",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");
        }
    }
}
