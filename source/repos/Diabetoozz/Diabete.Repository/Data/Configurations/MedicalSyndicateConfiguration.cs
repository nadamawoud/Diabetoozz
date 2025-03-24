using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class MedicalSyndicateConfiguration : IEntityTypeConfiguration<MedicalSyndicate>
    {
        public void Configure(EntityTypeBuilder<MedicalSyndicate> builder)
        {
            // تحديد اسم الجدول
            builder.ToTable("MedicalSyndicates");

            // تعيين المفتاح الأساسي
            builder.HasKey(ms => ms.MedicalSyndicateID);

            // ضبط الخصائص
            builder.Property(ms => ms.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(ms => ms.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(ms => ms.Phone)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(ms => ms.Address)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(ms => ms.ProfileDescription)
                .HasMaxLength(1000);

            builder.Property(ms => ms.Logo)
                .HasMaxLength(500);

            builder.Property(ms => ms.VerificationStatus)
                .IsRequired();

            builder.Property(ms => ms.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            // العلاقة مع الأطباء (One-to-Many)
            builder.HasMany(ms => ms.Doctors)
                .WithOne(d => d.MedicalSyndicate)
                .HasForeignKey(d => d.MedicalSyndicateID)
                .OnDelete(DeleteBehavior.Restrict);


            // العلاقة مع المنشورات (One-to-Many)
            builder.HasMany(ms => ms.NewsFeedPosts)
                .WithOne(nfp => nfp.MedicalSyndicate)
                .HasForeignKey(nfp => nfp.MedicalSyndicateID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}