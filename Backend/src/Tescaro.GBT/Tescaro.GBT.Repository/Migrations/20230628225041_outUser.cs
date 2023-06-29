using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tescaro.GBT.Repository.Migrations
{
    public partial class outUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BancoDados_AspNetUsers_UserId",
                table: "BancoDados");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_AspNetUsers_UserId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_DNS_AspNetUsers_UserId",
                table: "DNS");

            migrationBuilder.DropIndex(
                name: "IX_DNS_UserId",
                table: "DNS");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_UserId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_BancoDados_UserId",
                table: "BancoDados");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DNS");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BancoDados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "DNS",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Cliente",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "BancoDados",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_DNS_UserId",
                table: "DNS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UserId",
                table: "Cliente",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BancoDados_UserId",
                table: "BancoDados",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BancoDados_AspNetUsers_UserId",
                table: "BancoDados",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_AspNetUsers_UserId",
                table: "Cliente",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DNS_AspNetUsers_UserId",
                table: "DNS",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
