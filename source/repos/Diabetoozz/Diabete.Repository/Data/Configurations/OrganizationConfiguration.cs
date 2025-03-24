using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");

            builder.HasKey(o => o.OrganizationID);

            builder.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(o => o.Email)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(o => o.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            // علاقة One-to-Many مع Admin
            builder.HasOne(o => o.Admin)
                .WithMany(a => a.Organizations)
                .HasForeignKey(o => o.AdminID)
                .OnDelete(DeleteBehavior.Restrict);

            // علاقة One-to-Many مع NewsFeedPost
            builder.HasMany(o => o.NewsFeedPosts)
                .WithOne(nfp => nfp.Organization)
                .HasForeignKey(nfp => nfp.OrganizationID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}