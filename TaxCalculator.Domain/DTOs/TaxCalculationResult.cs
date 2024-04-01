namespace TaxCalculator.DB.Models
{
    public class TaxCalculationResultDTO
    {
        public int TaxCalculationResultId { get; set; }
        public int GrossAnnualSalary { get; set; }
        public int NetAnnualSalary { get; set; }
        public int AnnualTaxPaid { get; set; }
    }
}