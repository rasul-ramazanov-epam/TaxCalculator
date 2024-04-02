using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxCalculator.DB.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxBands",
                columns: table => new
                {
                    TaxBandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowerLimit = table.Column<int>(type: "int", nullable: false),
                    UpperLimit = table.Column<int>(type: "int", nullable: false),
                    TaxRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBands", x => x.TaxBandId);
                });

            migrationBuilder.CreateTable(
                name: "TaxCalculationResults",
                columns: table => new
                {
                    TaxCalculationResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrossAnnualSalary = table.Column<int>(type: "int", nullable: false),
                    NetAnnualSalary = table.Column<int>(type: "int", nullable: false),
                    AnnualTaxPaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCalculationResults", x => x.TaxCalculationResultId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxBands");

            migrationBuilder.DropTable(
                name: "TaxCalculationResults");
        }
    }
}
