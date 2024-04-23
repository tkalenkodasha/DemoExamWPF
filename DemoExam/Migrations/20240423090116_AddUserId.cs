using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoExam.Migrations
{
    public partial class AddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Employers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employers_UserID",
                table: "Employers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserID",
                table: "Clients",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserID",
                table: "Clients",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_Users_UserID",
                table: "Employers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Users_UserID",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Employers_UserID",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Clients");
        }
    }
}
