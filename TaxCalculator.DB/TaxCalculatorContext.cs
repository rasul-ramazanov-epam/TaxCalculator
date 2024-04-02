using Microsoft.EntityFrameworkCore;
using TaxCalculator.DB.Models;

namespace TaxCalculator.DB
{
    public class TaxCalculatorContext : DbContext
    {
        public virtual DbSet<TaxBand> TaxBands { get; set; }
        public virtual DbSet<TaxCalculationResult> TaxCalculationResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxBand>(entity =>
            {
                entity.ToTable("TaxBands");
                entity.HasKey(t => t.TaxBandId);
            });

            modelBuilder.Entity<TaxCalculationResult>(entity =>
            {
                entity.ToTable("TaxCalculationResults");
                entity.HasKey(t => t.TaxCalculationResultId);
            });

            modelBuilder.Entity<TaxBand>().HasData(
                new List<TaxBand>
                {
                    new TaxBand { TaxBandId = -1, LowerLimit = 0, UpperLimit = 5000, TaxRate = 10 },
                    new TaxBand { TaxBandId = -2, LowerLimit = 5000, UpperLimit = 20000, TaxRate = 20 },
                    new TaxBand { TaxBandId = -3, LowerLimit = 20000, UpperLimit = 1000000, TaxRate = 40 },
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=localhost;Database=TaxDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}