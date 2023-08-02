using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserModelCityEntityRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CityEntities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CityEntities_UserId",
                table: "CityEntities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityEntities_userEntities_UserId",
                table: "CityEntities",
                column: "UserId",
                principalTable: "userEntities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityEntities_userEntities_UserId",
                table: "CityEntities");

            migrationBuilder.DropIndex(
                name: "IX_CityEntities_UserId",
                table: "CityEntities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CityEntities");
        }
    }
}
