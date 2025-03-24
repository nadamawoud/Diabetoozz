using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class SuspectDiabetesResultConfiguration : IEntityTypeConfiguration<SuspectDiabetesResult>
    {
        public void Configure(EntityTypeBuilder<SuspectDiabetesResult> builder)
        {
            builder.ToTable("SuspectDiabetesResults");

            builder.HasKey(sdr => sdr.SuspectResultID);

            builder.Property(sdr => sdr.RiskLevel).HasMaxLength(50).IsRequired();
            builder.Property(sdr => sdr.Recommendation).HasMaxLength(1000);
            builder.Property(sdr => sdr.AnalysisDate).IsRequired();
        }
    }
}
