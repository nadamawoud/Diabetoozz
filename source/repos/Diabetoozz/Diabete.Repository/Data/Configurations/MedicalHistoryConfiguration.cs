using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class MedicalHistoryConfiguration : IEntityTypeConfiguration<MedicalHistory>
    {
        public void Configure(EntityTypeBuilder<MedicalHistory> builder)
        {
            // تحديد اسم الجدول
            builder.ToTable("MedicalHistories");

            // تعيين المفتاح الأساسي
            builder.HasKey(mh => mh.MedicalHistoryID);

            // ضبط الخصائص
            builder.Property(mh => mh.Diagnosis)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(mh => mh.ChatbotData)
                .HasMaxLength(2000);

            builder.Property(mh => mh.DiagnosisDate)
                .IsRequired();

            // العلاقة مع Admin (Many-to-One)
            builder.HasOne(mh => mh.Admin)
                .WithMany(a=>a.MedicalHistories) // إذا كان هناك Navigation Property في Admin تشير إلى MedicalHistory، استخدم WithMany(a => a.MedicalHistories)
                .HasForeignKey(mh => mh.AdminID)
                .OnDelete(DeleteBehavior.Restrict);


            // العلاقة مع Doctor (Many-to-One)
            builder.HasOne(mh => mh.Doctor)
                .WithMany(d => d.MedicalHistories)
                .HasForeignKey(mh => mh.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);


            // العلاقة مع Manager (Many-to-One)
            builder.HasOne(mh => mh.Manager)
                .WithMany(m => m.MedicalHistories)
                .HasForeignKey(mh => mh.ManagerID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}