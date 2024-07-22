using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimerAvancePOO2.Migrations
{
    /// <inheritdoc />
    public partial class TablaDeRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProveedorId",
                table: "Componentes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Componentes_ProveedorId",
                table: "Componentes",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Componentes_Proveedor_ProveedorId",
                table: "Componentes",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componentes_Proveedor_ProveedorId",
                table: "Componentes");

            migrationBuilder.DropIndex(
                name: "IX_Componentes_ProveedorId",
                table: "Componentes");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Componentes");
        }
    }
}
