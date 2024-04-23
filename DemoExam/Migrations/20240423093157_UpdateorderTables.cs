using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoExam.Migrations
{
    public partial class UpdateorderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PickUpPointId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PickUpPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Adress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUpPoints", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickUpPointId",
                table: "Orders",
                column: "PickUpPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PickUpPoints_PickUpPointId",
                table: "Orders",
                column: "PickUpPointId",
                principalTable: "PickUpPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PickUpPoints_PickUpPointId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "PickUpPoints");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PickUpPointId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PickUpPointId",
                table: "Orders");
        }
    }
}
