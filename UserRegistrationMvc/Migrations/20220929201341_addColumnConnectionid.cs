using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserRegistrationMvc.Migrations
{
    public partial class addColumnConnectionid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "Users");
        }
    }
}
