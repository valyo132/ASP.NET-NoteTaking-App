using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteTaking.Data.Migrations
{
    public partial class AddedProfilePictureToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageURL",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageURL",
                table: "AspNetUsers");
        }
    }
}
