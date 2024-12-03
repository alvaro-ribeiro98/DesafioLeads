using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioLeads.Migrations
{
    public partial class AdicionandoNovosCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "Leads",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobId",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Job",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Leads");
        }
    }
}
