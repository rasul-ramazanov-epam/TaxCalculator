using TaxCalculator.DB.Models;

namespace TaxCalculator.DB.Repositories.AbstractRepositories
{
    public interface ITaxBandRepository
    {
        Task<List<TaxBand>> GetAllTaxBands();
    }
}
