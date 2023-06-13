using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tescaro.GBT.Repository.Migrations
{
    public partial class Identity_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "AspNetUsers");
        }
    }
}
