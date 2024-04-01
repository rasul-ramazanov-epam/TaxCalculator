using TaxCalculator.DB.Models;

namespace TaxCalculator.Domain.Services.AbstractServices
{
    public interface ITaxCalculationResultService
    {
        Task<List<TaxCalculationResultDTO>> GetAllResults();
        Task AddResult(TaxCalculationResultDTO item);
        Task<TaxCalculationResultDTO> CalculateTax(decimal value, List<TaxBandDTO> taxBands);
    }
}