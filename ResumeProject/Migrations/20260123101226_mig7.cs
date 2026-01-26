using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeProject.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Messages",
                newName: "SenderEmail");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverEmail",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverEmail",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderEmail",
                table: "Messages",
                newName: "Email");
        }
    }
}
