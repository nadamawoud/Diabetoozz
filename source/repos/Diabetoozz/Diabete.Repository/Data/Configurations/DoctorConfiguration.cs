using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            // تحديد اسم الجدول
            builder.ToTable("Doctors");

            // تعيين المفتاح الأساسي
            builder.HasKey(d => d.DoctorID);

            // ضبط الخصائص
            builder.Property(d => d.DoctorID)
                .ValueGeneratedOnAdd();

            builder.Property(d => d.DoctorTitle)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(d => d.BirthDate)
                .IsRequired();

            builder.Property(d => d.Phone)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(d => d.Gender)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(d => d.MedicalSyndicateCardNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(d => d.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(d => d.VerificationStatus)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            // العلاقة مع Admin (Many-to-One)
            builder.HasOne(d => d.Admin)
                .WithMany(a=>a.Doctors) // إذا كان هناك Navigation Property في Admin تشير إلى Doctor، استخدم WithMany(a => a.Doctors)
                .HasForeignKey(d => d.AdminID)
                .OnDelete(DeleteBehavior.Restrict);


            // العلاقة مع MedicalSyndicate (Many-to-One)
            builder.HasOne(d => d.MedicalSyndicate)
                .WithMany(ms=>ms.Doctors) // إذا كان هناك Navigation Property في MedicalSyndicate تشير إلى Doctor، استخدم WithMany(ms => ms.Doctors)
                .HasForeignKey(d => d.MedicalSyndicateID)
                .OnDelete(DeleteBehavior.Restrict);


            // العلاقات مع الكيانات الأخرى (One-to-Many)
            builder.HasMany(d => d.MedicalHistories)
                .WithOne(mh => mh.Doctor)
                .HasForeignKey(mh => mh.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(d => d.Reports)
                .WithOne(r => r.Doctor)
                .HasForeignKey(r => r.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(d => d.Patients)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(d => d.ChatbotQuestionDoctors)
                .WithOne(cqd => cqd.Doctor)
                .HasForeignKey(cqd => cqd.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(d => d.Clerks)
                .WithOne(c => c.Doctor)
                .HasForeignKey(c => c.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}