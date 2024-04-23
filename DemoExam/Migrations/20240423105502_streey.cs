using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoExam.Migrations
{
    public partial class streey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "PickUpPoints",
                newName: "Street");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "PickUpPoints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Index",
                table: "PickUpPoints",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NumberHouse",
                table: "PickUpPoints",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PickUpPoints_CityId",
                table: "PickUpPoints",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PickUpPoints_Citys_CityId",
                table: "PickUpPoints",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PickUpPoints_Citys_CityId",
                table: "PickUpPoints");

            migrationBuilder.DropIndex(
                name: "IX_PickUpPoints_CityId",
                table: "PickUpPoints");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "PickUpPoints");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "PickUpPoints");

            migrationBuilder.DropColumn(
                name: "NumberHouse",
                table: "PickUpPoints");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "PickUpPoints",
                newName: "Adress");
        }
    }
}
