using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class productentitiesv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatagorySub",
                table: "CatagorySub");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatagorySub",
                table: "CatagorySub",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_ProductId",
                table: "ProductPicture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CatagorySub_CatagoryId",
                table: "CatagorySub",
                column: "CatagoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture");

            migrationBuilder.DropIndex(
                name: "IX_ProductPicture_ProductId",
                table: "ProductPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatagorySub",
                table: "CatagorySub");

            migrationBuilder.DropIndex(
                name: "IX_CatagorySub_CatagoryId",
                table: "CatagorySub");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture",
                columns: new[] { "ProductId", "PictureId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatagorySub",
                table: "CatagorySub",
                columns: new[] { "CatagoryId", "SubCatagoryId", "Id" });
        }
    }
}
