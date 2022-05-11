using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGitHub_ClonesTrainingRepoCookingRecipesSystemCookingRecipesSystemServerInfrastructurePersistenceMigrations
{
    public partial class AddRecipesConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatedBy",
                table: "Recipes",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_CreatedBy",
                table: "Recipes",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_CreatedBy",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CreatedBy",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
