using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoEFCore.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckConstraintAndData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Frais" },
                    { 2, "Condiment" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Salade du jardin", "Salade", 3.9900000000000002 },
                    { 2, 2, "Häagen-Dazs", "Glace", 7.9900000000000002 }
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Name",
                table: "Product",
                sql: "LEN(TRIM(Name)) > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Price",
                table: "Product",
                sql: "Price > 0");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Category_Name",
                table: "Category",
                sql: "LEN(TRIM(Name)) > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Name",
                table: "Product");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Price",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Category_Name",
                table: "Category");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Category_Name",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);
        }
    }
}
