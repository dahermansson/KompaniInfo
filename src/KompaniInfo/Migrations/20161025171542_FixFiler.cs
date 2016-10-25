using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KompaniInfo.Migrations
{
    public partial class FixFiler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"update fil set Typ = REPLACE(Typ, '.', '');  ";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
