using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiddleMaker.Data.Migrations
{
    public partial class ChangeRiddleMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Riddles",
                type: "nvarchar(210)",
                maxLength: 210,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Riddles",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(210)",
                oldMaxLength: 210);
        }
    }
}
