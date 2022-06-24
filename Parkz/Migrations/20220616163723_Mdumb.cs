using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parkz.Migrations
{
    public partial class Mdumb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dong",
                table: "Cars",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dong",
                table: "Cars");
        }
    }
}
