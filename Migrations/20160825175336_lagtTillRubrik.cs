using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KompaniInfo.Migrations
{
    public partial class lagtTillRubrik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rubrik",
                table: "Post",
                maxLength: 180,
                nullable: false,
                defaultValue: "Rubrik");

            migrationBuilder.AlterColumn<string>(
                name: "Innehall",
                table: "Post",
                nullable: false, 
				defaultValue: "DefaultInnehåll");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rubrik",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "Innehall",
                table: "Post",
                nullable: true);
        }
    }
}
