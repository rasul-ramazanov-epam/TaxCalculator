using Microsoft.EntityFrameworkCore;
using TaxCalculator.DB.Models;
using TaxCalculator.DB.Repositories.AbstractRepositories;

namespace TaxCalculator.DB.Repositories
{
    public class TaxCalculationResultRepository : ITaxCalculationResultRepository
    {
        private readonly TaxCalculatorContext _context;

        public TaxCalculationResultRepository(TaxCalculatorContext context)
        {
            _context = context;
        }

        public async Task<List<TaxCalculationResult>> GetAllResults()
        {
            return await _context.TaxCalculationResults.AsNoTracking().ToListAsync();
        }

        public async Task AddResult(TaxCalculationResult item)
        {
            await _context.TaxCalculationResults.AddAsync(item);
        }
    }
}