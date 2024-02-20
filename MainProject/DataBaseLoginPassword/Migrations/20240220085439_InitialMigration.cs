using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataBaseLoginPassword.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 0, "Admin" },
                    { 1, "Founder" },
                    { 2, "Follower" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "name", "password", "RoleId", "salt" },
                values: new object[,]
                {
                    { new Guid("808d561f-66a0-46bb-a7f3-173ac34bb0bb"), "KrotovAV@tut.by", new byte[] { 127, 199, 81, 185, 109, 169, 92, 155, 139, 226, 106, 166, 80, 6, 20, 16, 80, 81, 74, 115, 130, 4, 43, 185, 49, 244, 147, 61, 25, 254, 194, 221, 236, 17, 70, 145, 19, 53, 169, 4, 220, 36, 155, 201, 188, 243, 236, 36, 173, 23, 15, 92, 12, 188, 83, 18, 106, 161, 103, 85, 109, 139, 109, 62 }, 0, new byte[] { 130, 166, 203, 27, 198, 183, 112, 134, 155, 195, 16, 227, 140, 159, 86, 14 } },
                    { new Guid("c8820378-482a-4627-87fe-4a6d67436519"), "KrotovAV@tut.by", new byte[] { 98, 234, 85, 213, 149, 221, 253, 126, 159, 67, 227, 98, 18, 254, 113, 252, 205, 200, 108, 162, 150, 177, 131, 7, 32, 169, 65, 159, 228, 47, 75, 43, 162, 127, 186, 99, 168, 182, 159, 137, 73, 182, 245, 142, 129, 134, 11, 2, 146, 46, 217, 221, 95, 206, 178, 234, 193, 172, 172, 156, 31, 46, 255, 206 }, 1, new byte[] { 146, 155, 75, 36, 46, 250, 200, 196, 39, 104, 242, 215, 64, 107, 211, 255 } },
                    { new Guid("fba18122-d941-4ecb-a786-9bb7bdb6fc40"), "KrotovAV@tut.by", new byte[] { 232, 136, 11, 186, 146, 87, 208, 192, 226, 20, 233, 13, 100, 135, 78, 100, 94, 2, 162, 127, 234, 221, 204, 158, 163, 53, 250, 121, 193, 74, 89, 47, 252, 117, 72, 35, 165, 189, 250, 85, 145, 147, 78, 210, 226, 32, 97, 183, 39, 240, 222, 134, 82, 239, 63, 182, 125, 254, 32, 45, 149, 152, 69, 187 }, 2, new byte[] { 69, 34, 242, 91, 47, 163, 84, 237, 17, 78, 141, 42, 98, 208, 227, 61 } }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_name_RoleId",
                table: "Users",
                columns: new[] { "name", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
