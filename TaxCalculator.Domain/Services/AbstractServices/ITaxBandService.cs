using TaxCalculator.DB.Models;

namespace TaxCalculator.Domain.Services.AbstractServices
{
    public interface ITaxBandService
    {
        Task<List<TaxBandDTO>> GetAllTaxBands();
    }
}