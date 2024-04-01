using Microsoft.EntityFrameworkCore;
using TaxCalculator.DB.Models;

namespace TaxCalculator.DB.Repositories
{
    public class TaxBandRepository
    {
        private readonly TaxCalculatorContext _context;

        public TaxBandRepository(TaxCalculatorContext context)
        {
            _context = context;
        }

        public async Task<List<TaxBand>> GetAllTaxBands()
        {
            return await _context.TaxBands.OrderBy(t => t.UpperLimit).AsNoTracking().ToListAsync();
        }
    }
}