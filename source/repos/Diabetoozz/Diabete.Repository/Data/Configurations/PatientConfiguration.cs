using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(p => p.PatientID);

            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Gender).HasMaxLength(10).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired();

            builder.HasOne(p => p.Clerk)
                .WithMany(c=>c.Patients)
                .HasForeignKey(p => p.ClerkID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Doctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Diagnosis)
                .WithOne(d => d.Patient)
                .HasForeignKey<Diagnosis>(d => d.PatientID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.SuggestionFood)
                .WithOne(sf => sf.Patient)
                .HasForeignKey<SuggestionFood>(sf => sf.PatientID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}