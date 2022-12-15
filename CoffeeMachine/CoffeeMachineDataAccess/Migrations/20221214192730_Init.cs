using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeMachineDataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intensities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntensityNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intensities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coffees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoffeeTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coffees_CoffeeTypes_CoffeeTypeId",
                        column: x => x.CoffeeTypeId,
                        principalTable: "CoffeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeIngredientIntensities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    IntensityId = table.Column<int>(type: "int", nullable: false),
                    CoffeeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeIngredientIntensities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeIngredientIntensities_CoffeeTypes_CoffeeTypeId",
                        column: x => x.CoffeeTypeId,
                        principalTable: "CoffeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeIngredientIntensities_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeIngredientIntensities_Intensities_IntensityId",
                        column: x => x.IntensityId,
                        principalTable: "Intensities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CoffeeTypes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Latte", 24.0 },
                    { 2, "Macchiato", 50.0 },
                    { 3, "Espresso", 20.5 },
                    { 4, "Americano", 78.0 },
                    { 5, "Mocha", 27.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Milk", 5.0 },
                    { 2, "Sugar", 3.0 },
                    { 3, "Ice", 2.0 },
                    { 4, "Cream", 6.0 },
                    { 5, "Chocolate", 10.0 },
                    { 6, "Coffee", 10.0 }
                });

            migrationBuilder.InsertData(
                table: "Intensities",
                columns: new[] { "Id", "Description", "IntensityNumber" },
                values: new object[,]
                {
                    { 1, "Intensity of ingredient with the value of 1", 1 },
                    { 2, "Intensity of ingredient with the value of 2", 2 },
                    { 3, "Intensity of ingredient with the value of 3", 3 },
                    { 4, "Intensity of ingredient with the value of 4", 4 },
                    { 5, "Intensity of ingredient with the value of 5", 5 }
                });

            migrationBuilder.InsertData(
                table: "Coffees",
                columns: new[] { "Id", "CoffeeTypeId", "Description", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Latte Coffee", null },
                    { 2, 2, "Macchiato Coffee", null },
                    { 3, 3, "Espresso Coffee", null },
                    { 4, 4, "Americano Coffee", null },
                    { 5, 5, "Mocha Coffee", null }
                });

            migrationBuilder.InsertData(
                table: "TypeIngredientIntensities",
                columns: new[] { "Id", "CoffeeTypeId", "IngredientId", "IntensityId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 3 },
                    { 3, 3, 1, 2 },
                    { 4, 4, 4, 2 },
                    { 5, 5, 2, 3 },
                    { 6, 5, 5, 2 },
                    { 7, 2, 5, 4 },
                    { 8, 1, 2, 5 },
                    { 9, 2, 1, 1 },
                    { 10, 3, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coffees_CoffeeTypeId",
                table: "Coffees",
                column: "CoffeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeIngredientIntensities_CoffeeTypeId",
                table: "TypeIngredientIntensities",
                column: "CoffeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeIngredientIntensities_IngredientId",
                table: "TypeIngredientIntensities",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeIngredientIntensities_IntensityId",
                table: "TypeIngredientIntensities",
                column: "IntensityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coffees");

            migrationBuilder.DropTable(
                name: "TypeIngredientIntensities");

            migrationBuilder.DropTable(
                name: "CoffeeTypes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Intensities");
        }
    }
}
