using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class SymptomsConfiguration : IEntityTypeConfiguration<Symptoms>
    {
        public void Configure(EntityTypeBuilder<Symptoms> builder)
        {
            builder.ToTable("Symptoms");

            builder.HasKey(s => s.SymptomID);

            builder.Property(s => s.Name).HasMaxLength(200).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(1000);
            builder.Property(s => s.SeverityLevel).IsRequired();
            builder.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired();

            builder.HasOne(s => s.CasualUser)
                .WithMany(c=>c.Symptoms)
                .HasForeignKey(s => s.CasualUserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.SuspectDiabetesResult)
                .WithMany(sdr => sdr.Symptoms)
                .HasForeignKey(s => s.SuspectResultID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}