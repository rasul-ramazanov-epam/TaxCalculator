using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.DB.Models
{
    public class TaxBand
    {
        [Key]
        public int TaxBandId { get; set; }
        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }
        public int TaxRate { get; set; }
    }
}