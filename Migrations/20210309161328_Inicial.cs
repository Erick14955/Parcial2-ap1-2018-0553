using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcial2_ap1_2018_0553.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DescripcionProyecto = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoTotal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    TareaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTarea = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.TareaId);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoDetalle",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoTarea = table.Column<string>(type: "TEXT", nullable: true),
                    Requerimentos = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoDetalle", x => x.TipoId);
                    table.ForeignKey(
                        name: "FK_ProyectoDetalle_Proyectos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Proyectos",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "TipoTarea" },
                values: new object[] { 1, "Analisis" });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "TipoTarea" },
                values: new object[] { 2, "Diseño" });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "TipoTarea" },
                values: new object[] { 3, "Programación" });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "TipoTarea" },
                values: new object[] { 4, "Prueba" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectoDetalle");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
