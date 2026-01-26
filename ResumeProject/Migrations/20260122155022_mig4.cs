using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeProject.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "SkillTexts",
                columns: table => new
                {
                    SkillTextId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTexts", x => x.SkillTextId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillTexts");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
