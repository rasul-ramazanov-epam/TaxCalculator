using AutoMapper;
using TaxCalculator.DB.Models;

namespace TaxCalculator.Domain
{
    public class TaxProfile : Profile
    {
        public TaxProfile()
        {
            CreateMap<TaxBand, TaxBandDTO>();
            CreateMap<TaxCalculationResultDTO, TaxCalculationResult>();
        }
    }
}