using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Domain.Services.AbstractServices;

namespace TaxCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxBandService _taxBandService;
        private readonly ITaxCalculationResultService _calculationResultService;

        public TaxController(ITaxBandService taxBandService,
            ITaxCalculationResultService calculationResultService)
        {
            _taxBandService = taxBandService;
            _calculationResultService = calculationResultService;
        }

        [HttpPost]
        public async Task CalculateTax([FromBody] int value)
        {
            var taxBands = await _taxBandService.GetAllTaxBands();
            var result = await _calculationResultService.CalculateTax(value, taxBands);
            await _calculationResultService.AddResult(result);
        }
    }
}