using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteTaking.Data.Migrations
{
    public partial class AddedPinnPropToNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPinned",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPinned",
                table: "Notes");
        }
    }
}
