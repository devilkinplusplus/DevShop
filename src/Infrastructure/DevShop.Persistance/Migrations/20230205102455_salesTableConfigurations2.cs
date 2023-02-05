using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class salesTableConfigurations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_BuyerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_SellerId",
                table: "Sales");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_BuyerId",
                table: "Sales",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_SellerId",
                table: "Sales",
                column: "SellerId",
                principalTable: "Users",
                principalColumn: "Id");
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

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_BuyerId",
                table: "Sales",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_SellerId",
                table: "Sales",
                column: "SellerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
