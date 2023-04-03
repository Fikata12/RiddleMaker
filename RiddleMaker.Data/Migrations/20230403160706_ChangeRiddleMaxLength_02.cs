using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiddleMaker.Data.Migrations
{
    public partial class ChangeRiddleMaxLength_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Riddles",
                type: "nvarchar(217)",
                maxLength: 217,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(210)",
                oldMaxLength: 210);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Answers",
                type: "nvarchar(31)",
                maxLength: 31,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Riddles",
                type: "nvarchar(210)",
                maxLength: 210,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(217)",
                oldMaxLength: 217);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Answers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(31)",
                oldMaxLength: 31);
        }
    }
}
