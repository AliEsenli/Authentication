using Microsoft.EntityFrameworkCore.Migrations;

namespace Authentication.Persistence.Migrations
{
    public partial class _005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ApplicationId",
                table: "Role",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Role_ApplicationId",
                table: "Role",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Applications_ApplicationId",
                table: "Role",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Applications_ApplicationId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_ApplicationId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Role");
        }
    }
}
