using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tescaro.GBT.Repository.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gbt_BancoDados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChamadoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoDados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gbt_Chamado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataEnvioHomologacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScriptText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    BancoDadosId = table.Column<long>(type: "bigint", nullable: false),
                    DNSId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chamado_BancoDados_BancoDadosId",
                        column: x => x.BancoDadosId,
                        principalTable: "gbt_BancoDados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "gbt_DNS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    IsAtividade = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSemDNSAteMOMENTO = table.Column<bool>(type: "bit", nullable: false),
                    IsSemDNS = table.Column<bool>(type: "bit", nullable: false),
                    ChamadoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DNS_Chamado_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "gbt_Chamado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "gbt_Cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BancoDadosId = table.Column<long>(type: "bigint", nullable: true),
                    ChamadoId = table.Column<long>(type: "bigint", nullable: true),
                    DNSId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_BancoDados_BancoDadosId",
                        column: x => x.BancoDadosId,
                        principalTable: "gbt_BancoDados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cliente_Chamado_ChamadoId",
                        column: x => x.ChamadoId,
                        principalTable: "gbt_Chamado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cliente_DNS_DNSId",
                        column: x => x.DNSId,
                        principalTable: "gbt_DNS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BancoDados_ChamadoId",
                table: "gbt_BancoDados",
                column: "ChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_BancoDadosId",
                table: "gbt_Chamado",
                column: "BancoDadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_ClienteId",
                table: "gbt_Chamado",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_DNSId",
                table: "gbt_Chamado",
                column: "DNSId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_BancoDadosId",
                table: "gbt_Cliente",
                column: "BancoDadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ChamadoId",
                table: "gbt_Cliente",
                column: "ChamadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_DNSId",
                table: "gbt_Cliente",
                column: "DNSId");

            migrationBuilder.CreateIndex(
                name: "IX_DNS_ChamadoId",
                table: "gbt_DNS",
                column: "ChamadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BancoDados_Chamado_ChamadoId",
                table: "gbt_BancoDados",
                column: "ChamadoId",
                principalTable: "gbt_Chamado",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_Cliente_ClienteId",
                table: "gbt_Chamado",
                column: "ClienteId",
                principalTable: "gbt_Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_DNS_DNSId",
                table: "gbt_Chamado",
                column: "DNSId",
                principalTable: "gbt_DNS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BancoDados_Chamado_ChamadoId",
                table: "gbt_BancoDados");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Chamado_ChamadoId",
                table: "gbt_Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_DNS_Chamado_ChamadoId",
                table: "gbt_DNS");

            migrationBuilder.DropTable(
                name: "gbt_Chamado");

            migrationBuilder.DropTable(
                name: "gbt_Cliente");

            migrationBuilder.DropTable(
                name: "gbt_BancoDados");

            migrationBuilder.DropTable(
                name: "gbt_DNS");
        }
    }
}
