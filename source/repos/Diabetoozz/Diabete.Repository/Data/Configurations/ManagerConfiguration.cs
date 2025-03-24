using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            // تحديد اسم الجدول
            builder.ToTable("Managers");

            // تعيين المفتاح الأساسي
            builder.HasKey(m => m.ManagerID);

            // ضبط الخصائص
            builder.Property(m => m.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(m => m.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(m => m.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            // العلاقة مع Admin (Many-to-One)
            builder.HasOne(m => m.Admin)
                .WithMany(a=>a.Managers) // إذا كان هناك Navigation Property في Admin تشير إلى Manager، استخدم WithMany(a => a.Managers)
                .HasForeignKey(m => m.AdminID)
                .OnDelete(DeleteBehavior.Restrict);


            // العلاقة مع Reports (One-to-Many)
            builder.HasMany(m => m.Reports)
                .WithOne(r => r.Manager)
                .HasForeignKey(r => r.ManagerID)
                .OnDelete(DeleteBehavior.Restrict);


            // العلاقة مع MedicalHistories (One-to-Many)
            builder.HasMany(m => m.MedicalHistories)
                .WithOne(mh => mh.Manager)
                .HasForeignKey(mh => mh.ManagerID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}