using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");

            builder.HasKey(a => a.AdminID);

            builder.Property(a => a.Name).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Email).HasMaxLength(250).IsRequired();
            builder.Property(a => a.PasswordHash).HasMaxLength(500).IsRequired();

            // علاقة One-to-Many مع Organization
            builder.HasMany(a => a.Organizations)
                .WithOne(o => o.Admin)
                .HasForeignKey(o => o.AdminID);

            // علاقة One-to-Many مع Clerk
            builder.HasMany(a => a.Clerks)
                .WithOne(c => c.Admin)
                .HasForeignKey(c => c.AdminID);

            // علاقة One-to-Many مع Doctor
            builder.HasMany(a => a.Doctors)
                .WithOne(d => d.Admin)
                .HasForeignKey(d => d.AdminID);

            // علاقة One-to-Many مع CasualUser
            builder.HasMany(a => a.CasualUsers)
                .WithOne(cu => cu.Admin)
                .HasForeignKey(cu => cu.AdminID);

            // علاقة One-to-Many مع ChatbotQuestionDoctor
            builder.HasMany(a => a.ChatbotQuestionDoctors)
                .WithOne(cqd => cqd.Admin)
                .HasForeignKey(cqd => cqd.AdminID);

            // علاقة One-to-Many مع ChatbotQuestionCasualUser
            builder.HasMany(a => a.ChatbotQuestionCasualUsers)
                .WithOne(cqcu => cqcu.Admin)
                .HasForeignKey(cqcu => cqcu.AdminID);

            // علاقة One-to-Many مع Manager
            builder.HasMany(a => a.Managers)
                .WithOne(m => m.Admin)
                .HasForeignKey(m => m.AdminID);

            // علاقة One-to-Many مع MedicalHistory
            builder.HasMany(a => a.MedicalHistories)
                .WithOne(mh => mh.Admin)
                .HasForeignKey(mh => mh.AdminID);
        }
    }
}