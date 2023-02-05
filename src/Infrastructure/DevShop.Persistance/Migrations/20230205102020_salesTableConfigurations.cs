using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class salesTableConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Sales",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                newName: "IX_Sales_SellerId");

            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "Sales",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BuyerId",
                table: "Sales",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_BuyerId",
                table: "Sales",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_SellerId",
                table: "Sales",
                column: "SellerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_BuyerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_SellerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_BuyerId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Sales",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_SellerId",
                table: "Sales",
                newName: "IX_Sales_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
