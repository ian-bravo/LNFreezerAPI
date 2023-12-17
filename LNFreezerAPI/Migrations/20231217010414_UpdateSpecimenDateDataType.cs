using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LNFreezerAPI.Migrations
{
    public partial class UpdateSpecimenDateDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Specimens",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 1,
                column: "Date",
                value: "051422");

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 4,
                column: "Date",
                value: "052122");

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 10,
                column: "Date",
                value: "091722");

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 82,
                column: "Date",
                value: "062123");

            migrationBuilder.InsertData(
                table: "Specimens",
                columns: new[] { "SpecimenId", "BoxId", "Cohort", "Date", "NHPNum", "Quantity", "SpecimenNum", "Tissue" },
                values: new object[] { 100, 39, "PC521", "062823", 34331, "7e6", 81, "P.LN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Date",
                table: "Specimens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 1,
                column: "Date",
                value: 51422);

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 4,
                column: "Date",
                value: 52122);

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 10,
                column: "Date",
                value: 91722);

            migrationBuilder.UpdateData(
                table: "Specimens",
                keyColumn: "SpecimenId",
                keyValue: 82,
                column: "Date",
                value: 62123);
        }
    }
}
