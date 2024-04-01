namespace TaxCalculator.DB.Models
{
    public class TaxCalculationResultDTO
    {
        public decimal GrossAnnualSalary { get; set; }
        public decimal NetAnnualSalary { get; set; }
        public decimal AnnualTaxPaid { get; set; }
    }
}