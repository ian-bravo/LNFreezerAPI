using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNFreezerAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Boxes",
                columns: new[] { "BoxId", "BoxAlpha", "RackId" },
                values: new object[,]
                {
                    { 1, "A", 1 },
                    { 20, "A", 45 },
                    { 25, "C", 3 },
                    { 30, "D", 50 }
                });

            migrationBuilder.InsertData(
                table: "Freezers",
                columns: new[] { "FreezerId", "FreezerNum" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Racks",
                columns: new[] { "RackId", "FreezerId", "RackNum" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 6, 1, 6 },
                    { 10, 7, 30 },
                    { 50, 5, 30 }
                });

            migrationBuilder.InsertData(
                table: "Specimens",
                columns: new[] { "SpecimenId", "BoxId", "Cohort", "Date", "NHPNum", "Quantity", "SpecimenNum", "Tissue" },
                values: new object[,]
                {
                    { 1, 1, "PC475", 51422, 32283, "2e6", 1, "BM" },
                    { 4, 4, "PC475", 52122, 33887, "8e6", 4, "PBMC" },
                    { 10, 20, "PC498", 91722, 29396, "15e6", 10, "PBMC" },
                    { 82, 39, "PC521", 62123, 34331, "8e6", 1, "P.LN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "BoxId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "BoxId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "BoxId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "BoxId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Freezers",
                keyColumn: "FreezerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Freezers",
                keyColumn: "FreezerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Freezers",
                keyColumn: "FreezerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Racks",
                keyColumn: "RackId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Racks",
                keyColumn: "RackId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Racks",
                keyColumn: "RackId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Racks",
                keyColumn: "RackId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 82);
        }
    }
}
