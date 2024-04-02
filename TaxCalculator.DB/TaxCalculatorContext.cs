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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=localhost;Database=TaxDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}