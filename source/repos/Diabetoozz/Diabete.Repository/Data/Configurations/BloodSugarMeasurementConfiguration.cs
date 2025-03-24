using Diabetes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diabetes.Repository.Data.Configurations
{
    public class BloodSugarMeasurementConfiguration : IEntityTypeConfiguration<BloodSugarMeasurement>
    {
        public void Configure(EntityTypeBuilder<BloodSugarMeasurement> builder)
        {
            builder.ToTable("BloodSugarMeasurements");

            builder.HasKey(b => b.MeasurementID);

            builder.Property(b => b.MeasurementPeriod)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(b => b.GlucoseLevel)
                   .HasPrecision(18,2)
                   .IsRequired();
           

            builder.Property(b => b.MeasurementDate)
                   .IsRequired();

            builder.Property(b => b.Notes)
                   .HasMaxLength(500);

            // تحديد العلاقة بين CasualUser و BloodSugarMeasurement
            builder.HasOne(b => b.CasualUser)
                   .WithMany(c => c.BloodSugarMeasurements) // CasualUser يملك عدة قياسات للسكر
                   .HasForeignKey(b => b.CasualUserID)
                   .IsRequired();  // تحديد أن CasualUserID مطلوب (Not Nullable)
        }
    }
}