using TaxCalculator.DB.Repositories.AbstractRepositories;
using TaxCalculator.DB.Repositories;
using TaxCalculator.Domain;
using TaxCalculator.Domain.Services;
using TaxCalculator.Domain.Services.AbstractServices;
using TaxCalculator.DB;

namespace TaxCalculator
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(TaxProfile));

            services.AddScoped<ITaxBandService, TaxBandService>();
            services.AddScoped<ITaxCalculationResultService, TaxCalculationResultService>();

            services.AddScoped<ITaxBandRepository, TaxBandRepository>();
            services.AddScoped<ITaxCalculationResultRepository, TaxCalculationResultRepository>();

            services.AddDbContext<TaxCalculatorContext>();

            return services;
        }
    }
}