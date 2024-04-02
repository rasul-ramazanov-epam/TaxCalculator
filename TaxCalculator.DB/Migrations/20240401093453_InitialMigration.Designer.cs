﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxCalculator.DB;

#nullable disable

namespace TaxCalculator.DB.Migrations
{
    [DbContext(typeof(TaxCalculatorContext))]
    [Migration("20240401093453_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaxCalculator.DB.Models.TaxBand", b =>
                {
                    b.Property<int>("TaxBandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxBandId"), 1L, 1);

                    b.Property<int>("LowerLimit")
                        .HasColumnType("int");

                    b.Property<int>("TaxRate")
                        .HasColumnType("int");

                    b.Property<int>("UpperLimit")
                        .HasColumnType("int");

                    b.HasKey("TaxBandId");

                    b.ToTable("TaxBands", (string)null);
                });

            modelBuilder.Entity("TaxCalculator.DB.Models.TaxCalculationResult", b =>
                {
                    b.Property<int>("TaxCalculationResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxCalculationResultId"), 1L, 1);

                    b.Property<int>("AnnualTaxPaid")
                        .HasColumnType("int");

                    b.Property<int>("GrossAnnualSalary")
                        .HasColumnType("int");

                    b.Property<int>("NetAnnualSalary")
                        .HasColumnType("int");

                    b.HasKey("TaxCalculationResultId");

                    b.ToTable("TaxCalculationResults", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
