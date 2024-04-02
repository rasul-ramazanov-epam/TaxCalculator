using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxCalculator.DB.Migrations
{
    public partial class AddValuesForDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "TaxBandId", "LowerLimit", "TaxRate", "UpperLimit" },
                values: new object[] { -3, 20000, 40, 1000000 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "TaxBandId", "LowerLimit", "TaxRate", "UpperLimit" },
                values: new object[] { -2, 5000, 20, 20000 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "TaxBandId", "LowerLimit", "TaxRate", "UpperLimit" },
                values: new object[] { -1, 0, 10, 5000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "TaxBandId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "TaxBandId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "TaxBandId",
                keyValue: -1);
        }
    }
}
