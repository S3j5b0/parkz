using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parkz.Migrations
{
    public partial class Mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerModelId",
                table: "Purchases",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extras",
                table: "Cars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CustomerModelId",
                table: "Purchases",
                column: "CustomerModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Customers_CustomerModelId",
                table: "Purchases",
                column: "CustomerModelId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Customers_CustomerModelId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_CustomerModelId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CustomerModelId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Extras",
                table: "Cars");
        }
    }
}
