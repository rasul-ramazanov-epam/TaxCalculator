using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.DB.Models
{
    public class TaxCalculationResult
    {
        [Key]
        public int TaxCalculationResultId { get; set; }
        public int GrossAnnualSalary { get; set; }
        public int NetAnnualSalary { get; set; }
        public int AnnualTaxPaid { get; set; }
    }
}