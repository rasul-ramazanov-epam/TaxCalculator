using TaxCalculator.DB.Models;

namespace TaxCalculator.DB.Repositories.AbstractRepositories
{
    public interface ITaxCalculationResultRepository
    {
        Task<List<TaxCalculationResult>> GetAllResults();
        Task AddResult(TaxCalculationResult item);
    }
}
