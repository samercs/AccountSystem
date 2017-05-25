using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using AccountSystem.Core.Identity;

namespace AccountSystem.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var roles = new[] { Role.Administrator };

            foreach (var role in roles)
            {
                migrationBuilder.Sql(
                    $"insert into dbo.AspNetRoles (ConcurrencyStamp, Name, NormalizedName) values (LOWER(NEWID()), '{role}', '{role.ToUpper()}');");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from dbo.AspNetRoles");
        }
    }
}
