using AutoMapper;
using Moq;
using TaxCalculator.DB.Models;
using TaxCalculator.DB.Repositories.AbstractRepositories;
using TaxCalculator.Domain.Services;

namespace TaxCalculator.Test
{
    public class TaxCalculationResultServiceTests
    {
        [Fact]
        public async Task GetAllResults_ShouldReturnMappedResult()
        {
            // Arrange
            var expected = new List<TaxCalculationResult>
            {
                new TaxCalculationResult { TaxCalculationResultId = 1, GrossAnnualSalary = 50000, NetAnnualSalary = 42000, AnnualTaxPaid = 8000 },
                new TaxCalculationResult { TaxCalculationResultId = 2, GrossAnnualSalary = 60000, NetAnnualSalary = 50000, AnnualTaxPaid = 10000 },
            };

            var taxCalculationResultRepositoryMock = new Mock<ITaxCalculationResultRepository>();
            taxCalculationResultRepositoryMock.Setup(repo => repo.GetAllResults())
                .ReturnsAsync(expected);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaxCalculationResult, TaxCalculationResultDTO>();
            });

            var mapper = mapperConfig.CreateMapper();

            var taxCalculationResultService = new TaxCalculationResultService(taxCalculationResultRepositoryMock.Object, mapper);

            // Act
            var result = await taxCalculationResultService.GetAllResults();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Count, result.Count);
            Assert.IsType<List<TaxCalculationResultDTO>>(result);
        }

        [Fact]
        public async Task CalculateTax_ShouldReturnCorrectResult()
        {
            // Arrange
            var value = 50000;
            var taxBands = new List<TaxBandDTO> 
            {
                new TaxBandDTO { LowerLimit = 0, UpperLimit = 10000, TaxRate = 10 },
                new TaxBandDTO { LowerLimit = 10000, UpperLimit = 500000, TaxRate = 15 },
            };

            var expectedNetAnnualSalary = 43000;
            var expectedAnnualTaxPaid = 7000;

            var taxCalculationResultService = new TaxCalculationResultService(
                Mock.Of<ITaxCalculationResultRepository>(),
                Mock.Of<IMapper>());

            // Act
            var result = await taxCalculationResultService.CalculateTax(value, taxBands);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(value, result.GrossAnnualSalary);
            Assert.Equal(expectedNetAnnualSalary, result.NetAnnualSalary);
            Assert.Equal(expectedAnnualTaxPaid, result.AnnualTaxPaid);
        }
    }
}
