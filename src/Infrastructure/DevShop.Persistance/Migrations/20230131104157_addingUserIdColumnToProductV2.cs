using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addingUserIdColumnToProductV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_UserId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_UserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserId",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId1",
                table: "Product",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_UserId1",
                table: "Product",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
