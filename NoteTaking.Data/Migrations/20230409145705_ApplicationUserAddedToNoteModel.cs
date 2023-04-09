using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteTaking.Data.Migrations
{
    public partial class ApplicationUserAddedToNoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_ApplicationUserId",
                table: "Notes");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Notes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_ApplicationUserId",
                table: "Notes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_ApplicationUserId",
                table: "Notes");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Notes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_ApplicationUserId",
                table: "Notes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
