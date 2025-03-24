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
    internal class CasualUserConfiguration : IEntityTypeConfiguration<CasualUser>
    {
        public void Configure(EntityTypeBuilder<CasualUser> builder)
        {
            

            builder.HasOne(c => c.Admin)
                   .WithMany(a => a.CasualUsers)  // الإداري يملك عدة مستخدمين
                   .HasForeignKey(c => c.AdminID);  // تحديد المفتاح الأجنبي

            // تحديد أن AdminID مطلوب (Not Nullable)
            builder.Property(c => c.AdminID)
                   .IsRequired();
        }
    }
}
