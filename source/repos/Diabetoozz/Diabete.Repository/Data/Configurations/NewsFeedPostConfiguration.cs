using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class NewsFeedPostConfiguration : IEntityTypeConfiguration<NewsFeedPost>
    {
        public void Configure(EntityTypeBuilder<NewsFeedPost> builder)
        {
            // تحديد اسم الجدول
            builder.ToTable("NewsFeedPosts");

            // تعيين المفتاح الأساسي
            builder.HasKey(nfp => nfp.NewsFeedPostID);

            // ضبط الخصائص
            builder.Property(nfp => nfp.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(nfp => nfp.Content)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(nfp => nfp.ImageURL)
                .HasMaxLength(500);

            builder.Property(nfp => nfp.VideoURL)
                .HasMaxLength(500);

            builder.Property(nfp => nfp.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            // العلاقة مع MedicalSyndicate (Many-to-One)
            builder.HasOne(nfp => nfp.MedicalSyndicate)
                .WithMany(ms => ms.NewsFeedPosts)
                .HasForeignKey(nfp => nfp.MedicalSyndicateID)
                .OnDelete(DeleteBehavior.Restrict);


            // العلاقة مع Organization (Many-to-One)
            builder.HasOne(nfp => nfp.Organization)
                .WithMany(o => o.NewsFeedPosts)
                .HasForeignKey(nfp => nfp.OrganizationID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}