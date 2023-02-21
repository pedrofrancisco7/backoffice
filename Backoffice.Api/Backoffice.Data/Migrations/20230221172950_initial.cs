using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backoffice.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoPessoa = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    IdEndereco = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualificacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualificacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdResponsavel = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Pessoas_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ibge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ddd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    siafi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    erro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoasQualificacoes",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQualificacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasQualificacoes", x => new { x.IdPessoa, x.IdQualificacao });
                    table.ForeignKey(
                        name: "FK_PessoasQualificacoes_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoasQualificacoes_Qualificacoes_IdQualificacao",
                        column: x => x.IdQualificacao,
                        principalTable: "Qualificacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Qualificacoes",
                columns: new[] { "Id", "AtualizadoEm", "CriadoEm", "Nome", "Status" },
                values: new object[,]
                {
                    { new Guid("044013c5-3dc4-403d-ac4e-a78dd0284356"), null, new DateTime(2023, 2, 21, 14, 29, 50, 534, DateTimeKind.Local).AddTicks(5030), "Cliente", 1 },
                    { new Guid("3f3b7b6a-d2f0-416f-b61c-c394fd8710be"), null, new DateTime(2023, 2, 21, 14, 29, 50, 534, DateTimeKind.Local).AddTicks(5100), "Colaborador", 1 },
                    { new Guid("c3e1ac1e-c260-438f-b800-3d6bfa3cd349"), null, new DateTime(2023, 2, 21, 14, 29, 50, 534, DateTimeKind.Local).AddTicks(5090), "Fornecedor", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_IdResponsavel",
                table: "Departamentos",
                column: "IdResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Nome",
                table: "Departamentos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdPessoa",
                table: "Endereco",
                column: "IdPessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Documento",
                table: "Pessoas",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoasQualificacoes_IdQualificacao",
                table: "PessoasQualificacoes",
                column: "IdQualificacao");

            migrationBuilder.CreateIndex(
                name: "IX_Qualificacoes_Nome",
                table: "Qualificacoes",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "PessoasQualificacoes");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Qualificacoes");
        }
    }
}
