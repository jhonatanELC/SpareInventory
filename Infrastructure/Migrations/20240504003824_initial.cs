using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Year = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Spares",
                columns: table => new
                {
                    SpareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OemCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Group = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spares", x => x.SpareId);
                    table.ForeignKey(
                        name: "FK_Spares_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SpareBrands",
                columns: table => new
                {
                    SpareBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CodeByBrand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SpareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareBrands", x => x.SpareBrandId);
                    table.ForeignKey(
                        name: "FK_SpareBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpareBrands_Spares_SpareId",
                        column: x => x.SpareId,
                        principalTable: "Spares",
                        principalColumn: "SpareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "smallmoney", nullable: false),
                    SellPrice = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Igv = table.Column<short>(type: "smallint", nullable: false),
                    ProfitMargin = table.Column<short>(type: "smallint", nullable: false),
                    SpareBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceId);
                    table.ForeignKey(
                        name: "FK_Prices_SpareBrands_SpareBrandId",
                        column: x => x.SpareBrandId,
                        principalTable: "SpareBrands",
                        principalColumn: "SpareBrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prices_SpareBrandId",
                table: "Prices",
                column: "SpareBrandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpareBrands_BrandId",
                table: "SpareBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_SpareBrands_SpareId_BrandId",
                table: "SpareBrands",
                columns: new[] { "SpareId", "BrandId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spares_Sku",
                table: "Spares",
                column: "Sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spares_VehicleId",
                table: "Spares",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Brand_Model",
                table: "Vehicles",
                columns: new[] { "Brand", "Model" },
                unique: true,
                filter: "[Model] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "SpareBrands");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Spares");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
