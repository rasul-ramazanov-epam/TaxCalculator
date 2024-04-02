using AutoMapper;
using Moq;
using TaxCalculator.DB.Models;
using TaxCalculator.DB.Repositories.AbstractRepositories;
using TaxCalculator.Domain.Services;

namespace TaxCalculator.Test
{
    public class TaxBandServiceTests
    {
        [Fact]
        public async Task GetAllTaxBands_ShouldReturnMappedResult()
        {
            // Arrange
            var taxBands = new List<TaxBand> 
            {
                new TaxBand { TaxBandId = 1, LowerLimit = 0, UpperLimit = 10000, TaxRate = 10 },
                new TaxBand { TaxBandId = 2, LowerLimit = 10001, UpperLimit = 50000, TaxRate = 15 },
            };

            var taxBandRepositoryMock = new Mock<ITaxBandRepository>();
            taxBandRepositoryMock.Setup(repo => repo.GetAllTaxBands())
                .ReturnsAsync(taxBands);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaxBand, TaxBandDTO>();
            });

            var mapper = mapperConfig.CreateMapper();

            var taxBandService = new TaxBandService(taxBandRepositoryMock.Object, mapper);

            // Act
            var result = await taxBandService.GetAllTaxBands();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(taxBands.Count, result.Count);
            Assert.IsType<List<TaxBandDTO>>(result);
        }
    }
}