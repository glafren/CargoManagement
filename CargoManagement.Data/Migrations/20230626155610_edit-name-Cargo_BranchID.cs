using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class editnameCargo_BranchID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Branches_BranchId",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "DepartureBranchId",
                table: "Cargos");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "Cargos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Branches_BranchId",
                table: "Cargos",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Branches_BranchId",
                table: "Cargos");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "Cargos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartureBranchId",
                table: "Cargos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Branches_BranchId",
                table: "Cargos",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
