using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace demo.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shirts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Shirts",
                columns: new[] { "Id", "Brand", "Color", "Gender", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "Nike", "red", "men", 49.990000000000002, 8 },
                    { 2, "Adidas", "blue", "women", 39.990000000000002, 7 },
                    { 3, "Puma", "green", "men", 29.989999999999998, 12 },
                    { 4, "Reebok", "black", "women", 59.990000000000002, 6 },
                    { 5, "Under Armour", "gray", "men", 79.989999999999995, 9 },
                    { 6, "Fila", "white", "women", 34.990000000000002, 7 },
                    { 7, "New Balance", "purple", "men", 54.990000000000002, 10 },
                    { 8, "Asics", "yellow", "women", 44.990000000000002, 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shirts");
        }
    }
}
