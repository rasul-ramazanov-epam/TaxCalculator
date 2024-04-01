using AutoMapper;
using TaxCalculator.DB.Models;
using TaxCalculator.DB.Repositories.AbstractRepositories;
using TaxCalculator.Domain.Services.AbstractServices;

namespace TaxCalculator.Domain.Services
{
    public class TaxBandService : ITaxBandService
    {
        private readonly ITaxBandRepository _taxBandRepository;
        private readonly IMapper _mapper;

        public TaxBandService(ITaxBandRepository taxBandRepository,
            IMapper mapper)
        {
            _taxBandRepository = taxBandRepository;
            _mapper = mapper;
        }

        public async Task<List<TaxBandDTO>> GetAllTaxBands()
        {
            var result = await _taxBandRepository.GetAllTaxBands();
            return _mapper.Map<List<TaxBandDTO>>(result);
        }
    }
}