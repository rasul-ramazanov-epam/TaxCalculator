using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.DB.Models
{
    public class TaxCalculationResult
    {
        [Key]
        public int TaxCalculationResultId { get; set; }
        public decimal GrossAnnualSalary { get; set; }
        public decimal NetAnnualSalary { get; set; }
        public decimal AnnualTaxPaid { get; set; }
    }
}