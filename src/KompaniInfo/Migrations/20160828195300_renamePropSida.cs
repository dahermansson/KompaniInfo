using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KompaniInfo.Migrations
{
    public partial class renamePropSida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.RenameColumn(name: "Innahall", table: "Sida", newName: "Innehall");

			/*migrationBuilder.DropColumn(
                name: "Innahall",
                table: "Sida");

            migrationBuilder.AddColumn<string>(
                name: "Innehall",
                table: "Sida",
                nullable: false,
                defaultValue: "");
			*/    
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.RenameColumn(name: "Innehall", table: "Sida", newName: "Innahall");

			/*
			migrationBuilder.DropColumn(
                name: "Innehall",
                table: "Sida");

            migrationBuilder.AddColumn<string>(
                name: "Innahall",
                table: "Sida",
                nullable: false,
                defaultValue: "");
			*/
        }
    }
}
