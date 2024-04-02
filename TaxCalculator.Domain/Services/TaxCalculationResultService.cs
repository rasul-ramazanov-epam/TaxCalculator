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

        public async Task<TaxCalculationResultDTO> CalculateTax(decimal value, List<TaxBandDTO> taxBands)
        {
            decimal totalTaxPaid = 0;
            foreach (var taxBand in taxBands)
            {
                if (value > taxBand.LowerLimit)
                {
                    decimal taxableAmount = (Math.Min(value, taxBand.UpperLimit) - taxBand.LowerLimit);
                    decimal taxPaid = taxableAmount * (decimal)taxBand.TaxRate / 100;
                    totalTaxPaid += taxPaid;
                }
            }

            decimal netAnnualSalary = value - totalTaxPaid;

            var calculationResult = new TaxCalculationResultDTO
            {
                GrossAnnualSalary = value,
                NetAnnualSalary = netAnnualSalary,
                AnnualTaxPaid = totalTaxPaid,
            };

            return calculationResult;
        }
    }
}