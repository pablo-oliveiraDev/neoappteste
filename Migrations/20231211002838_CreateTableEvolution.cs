using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace csharp_docker_postgree_api.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableEvolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evolution",
                columns: table => new
                {
                    EvollutionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescribeEvolution = table.Column<string>(type: "text", nullable: false),
                    ConsultId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evolution", x => x.EvollutionId);
                    table.ForeignKey(
                        name: "FK_Evolution_Consult_ConsultId",
                        column: x => x.ConsultId,
                        principalTable: "Consult",
                        principalColumn: "ConsultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Medicinals = table.Column<string>(type: "text", nullable: false),
                    Dosgae = table.Column<string>(type: "text", nullable: false),
                    Instructions = table.Column<string>(type: "text", nullable: false),
                    ConsultId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescription_Consult_ConsultId",
                        column: x => x.ConsultId,
                        principalTable: "Consult",
                        principalColumn: "ConsultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evolution_ConsultId",
                table: "Evolution",
                column: "ConsultId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_ConsultId",
                table: "Prescription",
                column: "ConsultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evolution");

            migrationBuilder.DropTable(
                name: "Prescription");
        }
    }
}
