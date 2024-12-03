using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioLeads.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Suburb = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Category = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads");
        }
    }
}
