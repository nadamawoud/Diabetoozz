using Diabetes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabete.Repository.Data.Configurations
{
    internal class ClerkConfiguration : IEntityTypeConfiguration<Clerk>
    {
        public void Configure(EntityTypeBuilder<Clerk> builder)
    {


        // علاقة One-to-One بين Doctor و Clerk
        builder.HasOne(c => c.Doctor)
               .WithMany(d => d.Clerks)
               .HasForeignKey(c => c.DoctorID)
               .OnDelete(DeleteBehavior.Restrict);


            // علاقة One-to-Many بين Admin و Clerk
            builder.HasOne(c => c.Admin)
               .WithMany(a => a.Clerks)  // الإداري يملك عدة موظفين
               .HasForeignKey(c => c.AdminID)
               .OnDelete(DeleteBehavior.Restrict);

            // علاقة One-to-Many بين Clerk و Patient
            builder.HasMany(c => c.Patients)
               .WithOne(p => p.Clerk)  // الموظف يملك عدة مرضى
               .HasForeignKey(p => p.ClerkID)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
   
