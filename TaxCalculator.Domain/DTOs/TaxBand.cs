namespace TaxCalculator.DB.Models
{
    public class TaxBandDTO
    {
        public int TaxBandId { get; set; }
        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }
        public int TaxRate { get; set; }
    }
}