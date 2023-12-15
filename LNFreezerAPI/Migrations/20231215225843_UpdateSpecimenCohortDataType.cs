using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNFreezerAPI.Migrations
{
    public partial class UpdateSpecimenCohortDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "BoxId",
                keyValue: 1);

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

            migrationBuilder.AlterColumn<string>(
                name: "Cohort",
                table: "Specimens",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cohort",
                table: "Specimens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Boxes",
                columns: new[] { "BoxId", "BoxAlpha", "RackId" },
                values: new object[] { 1, "A", 1 });

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
        }
    }
}
