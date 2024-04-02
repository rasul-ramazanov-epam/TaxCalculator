using Microsoft.EntityFrameworkCore;
using TaxCalculator.DB.Models;
using TaxCalculator.DB.Repositories.AbstractRepositories;

namespace TaxCalculator.DB.Repositories
{
    public class TaxBandRepository : ITaxBandRepository
    {
        private readonly TaxCalculatorContext _context;

        public TaxBandRepository(TaxCalculatorContext context)
        {
            _context = context;
        }

        public async Task<List<TaxBand>> GetAllTaxBands()
        {
            return await _context.TaxBands.OrderByDescending(t => t.UpperLimit).AsNoTracking().ToListAsync();
        }
    }
}