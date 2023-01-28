using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class productentitiesv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_UserId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatagorySub",
                table: "CatagorySub");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture",
                columns: new[] { "ProductId", "PictureId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatagorySub",
                table: "CatagorySub",
                columns: new[] { "CatagoryId", "SubCatagoryId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Users_UserId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatagorySub",
                table: "CatagorySub");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture",
                columns: new[] { "ProductId", "PictureId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatagorySub",
                table: "CatagorySub",
                columns: new[] { "CatagoryId", "SubCatagoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Users_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
