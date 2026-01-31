using Microsoft.EntityFrameworkCore;
using SmartTaxAssistant.Web.Models;

namespace SmartTaxAssistant.Web.Data
{
    public class SmartTaxContext : DbContext
    {
        public SmartTaxContext(DbContextOptions<SmartTaxContext> options) : base(options) { }

        public DbSet<Taxpayer> Taxpayers => Set<Taxpayer>();
        public DbSet<CorporateClient> CorporateClients => Set<CorporateClient>();
        public DbSet<TaxReturn> TaxReturns => Set<TaxReturn>();
        public DbSet<PdfDocument> PdfDocuments => Set<PdfDocument>();
        public DbSet<ExtractedLineItem> ExtractedLineItems => Set<ExtractedLineItem>();
        public DbSet<TaxCategory> TaxCategories => Set<TaxCategory>();
        public DbSet<QuestionnaireQuestion> QuestionnaireQuestions => Set<QuestionnaireQuestion>();
        public DbSet<QuestionnaireAnswer> QuestionnaireAnswers => Set<QuestionnaireAnswer>();
        public DbSet<TaxRule> TaxRules => Set<TaxRule>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Taxpayer Configuration
            modelBuilder.Entity<Taxpayer>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.SIN).HasMaxLength(20);
                entity.Property(e => e.DateOfBirth).HasColumnType("DATE");
                entity.Property(e => e.ResidencyProvince).HasMaxLength(50);
            });

            // TaxReturn Configuration
            modelBuilder.Entity<TaxReturn>(entity =>
            {
                entity.Property(e => e.ReturnType).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Status).HasMaxLength(20).IsRequired();
                entity.Property(e => e.TotalIncome).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TotalTaxPaid).HasColumnType("decimal(18,2)");
                entity.Property(e => e.EstimatedBalance).HasColumnType("decimal(18,2)");
            });
            
            // ExtractedLineItem Configuration
            modelBuilder.Entity<ExtractedLineItem>(entity =>
            {
               entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            });
        }
    }
}
