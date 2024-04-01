using AutoMapper;
using TaxCalculator.DB.Models;
using TaxCalculator.DB.Repositories.AbstractRepositories;
using TaxCalculator.Domain.Services.AbstractServices;

namespace TaxCalculator.Domain.Services
{
    public class TaxCalculationResultService : ITaxCalculationResultService
    {
        private readonly ITaxCalculationResultRepository _taxCalculationResultRepository;
        private readonly IMapper _mapper;

        public TaxCalculationResultService(ITaxCalculationResultRepository taxCalculationResultRepository,
            IMapper mapper)
        {
            _taxCalculationResultRepository = taxCalculationResultRepository;
            _mapper = mapper;
        }

        public async Task<List<TaxCalculationResultDTO>> GetAllResults()
        {
            var results = await _taxCalculationResultRepository.GetAllResults();
            return _mapper.Map<List<TaxCalculationResultDTO>>(results);
        }

        public async Task AddResult(TaxCalculationResultDTO item)
        {
            var result = _mapper.Map<TaxCalculationResult>(item);
            await _taxCalculationResultRepository.AddResult(result);
        }
    }
}