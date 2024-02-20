using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directry",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("directry_primary_key", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Html = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("material_primary_key", x => x.id);
                    table.ForeignKey(
                        name: "FK_Material_Directry_DirectryId",
                        column: x => x.DirectryId,
                        principalTable: "Directry",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directry",
                columns: new[] { "id", "Html", "Title" },
                values: new object[,]
                {
                    { 1, "<b>Directory Content</b>", "First Directory" },
                    { 2, "<b>Directory Content</b>", "Second Directory" }
                });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "id", "DirectryId", "Html", "Title" },
                values: new object[,]
                {
                    { 1, 1, "<i>Material Content</i>", "First Material" },
                    { 2, 2, "<i>Material Content</i>", "Second Material" },
                    { 3, 2, "<i>Material Content</i>", "Third Material" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directry_id",
                table: "Directry",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_DirectryId",
                table: "Material",
                column: "DirectryId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_id",
                table: "Material",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Directry");
        }
    }
}
