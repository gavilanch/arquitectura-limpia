using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DientesLimpios.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class ColumnasAuditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreadoPor",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Pacientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Pacientes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UltimaModificacionPor",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPor",
                table: "Dentistas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Dentistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Dentistas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UltimaModificacionPor",
                table: "Dentistas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPor",
                table: "Consultorios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Consultorios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Consultorios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UltimaModificacionPor",
                table: "Consultorios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPor",
                table: "Citas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Citas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Citas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UltimaModificacionPor",
                table: "Citas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreadoPor",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "UltimaFechaModificacion",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "UltimaModificacionPor",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "CreadoPor",
                table: "Dentistas");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Dentistas");

            migrationBuilder.DropColumn(
                name: "UltimaFechaModificacion",
                table: "Dentistas");

            migrationBuilder.DropColumn(
                name: "UltimaModificacionPor",
                table: "Dentistas");

            migrationBuilder.DropColumn(
                name: "CreadoPor",
                table: "Consultorios");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Consultorios");

            migrationBuilder.DropColumn(
                name: "UltimaFechaModificacion",
                table: "Consultorios");

            migrationBuilder.DropColumn(
                name: "UltimaModificacionPor",
                table: "Consultorios");

            migrationBuilder.DropColumn(
                name: "CreadoPor",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "UltimaFechaModificacion",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "UltimaModificacionPor",
                table: "Citas");
        }
    }
}
