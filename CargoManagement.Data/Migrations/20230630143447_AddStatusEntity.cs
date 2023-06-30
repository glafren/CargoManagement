using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cargos");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Cargos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_StatusId",
                table: "Cargos",
                column: "StatusId",
                unique: true,
                filter: "[StatusId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Statuses_StatusId",
                table: "Cargos",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Statuses_StatusId",
                table: "Cargos");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_StatusId",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Cargos");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Cargos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
