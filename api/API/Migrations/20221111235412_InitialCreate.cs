using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muscles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuscleActivationData",
                columns: table => new
                {
                    MoveId = table.Column<Guid>(type: "uuid", nullable: false),
                    MuscleId = table.Column<Guid>(type: "uuid", nullable: false),
                    EfMuscleId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleActivationData", x => new { x.MoveId, x.MuscleId });
                    table.ForeignKey(
                        name: "FK_MuscleActivationData_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuscleActivationData_Muscles_EfMuscleId",
                        column: x => x.EfMuscleId,
                        principalTable: "Muscles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MuscleActivationData_Muscles_MuscleId",
                        column: x => x.MuscleId,
                        principalTable: "Muscles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuscleConnections",
                columns: table => new
                {
                    AncestorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DescendantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Depth = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleConnections", x => new { x.AncestorId, x.DescendantId });
                    table.ForeignKey(
                        name: "FK_MuscleConnections_Muscles_AncestorId",
                        column: x => x.AncestorId,
                        principalTable: "Muscles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuscleConnections_Muscles_DescendantId",
                        column: x => x.DescendantId,
                        principalTable: "Muscles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MuscleActivationData_EfMuscleId",
                table: "MuscleActivationData",
                column: "EfMuscleId");

            migrationBuilder.CreateIndex(
                name: "IX_MuscleActivationData_MuscleId",
                table: "MuscleActivationData",
                column: "MuscleId");

            migrationBuilder.CreateIndex(
                name: "IX_MuscleConnections_DescendantId",
                table: "MuscleConnections",
                column: "DescendantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuscleActivationData");

            migrationBuilder.DropTable(
                name: "MuscleConnections");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Muscles");
        }
    }
}
