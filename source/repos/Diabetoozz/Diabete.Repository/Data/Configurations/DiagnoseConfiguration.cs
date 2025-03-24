using Diabetes.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabete.Repository.Data.Configurations
{
    internal class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.HasOne(d => d.Patient)
                   .WithOne(p => p.Diagnosis)  // المريض يملك عدة تشخيصات
                   .HasForeignKey<Diagnosis>(d => d.PatientID)// تحديد المفتاح الأجنبي
                   .OnDelete(DeleteBehavior.Restrict);
            // تحديد أن PatientID مطلوب (Not Nullable)
            builder.Property(d => d.PatientID)
                   .IsRequired();
            // تحديد العلاقة بين Diagnosis و Disease
            builder.HasOne(d => d.Disease)
                   .WithMany()  // لا نريد أن تحتوي Disease على قائمة Diagnoses
                   .HasForeignKey(d => d.DiseaseID)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}