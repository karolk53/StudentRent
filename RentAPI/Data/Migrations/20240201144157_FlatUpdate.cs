using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class FlatUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Flats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Surface",
                table: "Flats",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Flats_OwnerId",
                table: "Flats",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_AspNetUsers_OwnerId",
                table: "Flats",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_AspNetUsers_OwnerId",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_OwnerId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Surface",
                table: "Flats");
        }
    }
}
