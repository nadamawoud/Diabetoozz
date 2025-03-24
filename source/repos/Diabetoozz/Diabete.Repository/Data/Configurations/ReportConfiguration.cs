using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");

            builder.HasKey(r => r.ReportID);

            builder.Property(r => r.ReportType).HasMaxLength(100).IsRequired();
            builder.Property(r => r.Format).HasMaxLength(50).IsRequired();
            builder.Property(r => r.FilePath).HasMaxLength(500);
            builder.Property(r => r.GeneratedAt).HasDefaultValueSql("GETDATE()").IsRequired();

            builder.HasOne(r => r.Doctor)
                .WithMany(d => d.Reports)
                .HasForeignKey(r => r.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Manager)
                .WithMany(m => m.Reports)
                .HasForeignKey(r => r.ManagerID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.CasualUser)
                .WithMany(c=>c.Reports)
                .HasForeignKey(r => r.CasualUserID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}