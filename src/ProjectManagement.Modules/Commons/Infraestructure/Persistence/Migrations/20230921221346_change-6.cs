using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Modules.Commons.Infraestructure.Persistence.Migrations
{
    public partial class change6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripción",
                table: "Proyect",
                newName: "Descripcion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Proyect",
                newName: "Descripción");
        }
    }
}
