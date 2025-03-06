using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            // Seed the Products table directly during migration
         
            Product[] products = InitialDataSeeder.GetProducts();
            object[,] values = new object[products.Length, 4];

            int i = 0;
            foreach (Product product in products)
            {
                values[i, 0] = product.Name;
                values[i, 1] = product.ImgUri;
                values[i, 2] = product.Price;
                values[i, 3] = product.Description;
                i++;
            }

            migrationBuilder.InsertData(
                table: "Products",
                columns: ["Name", "ImgUri", "Price", "Description"],
                values: values
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
