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
    internal class AlarmConfiguration : IEntityTypeConfiguration<Alarm>
    {
        public void Configure(EntityTypeBuilder<Alarm> builder)
        {

            // تكوين العلاقة مع CasualUser
            builder.HasOne(a => a.CasualUser)
                   .WithMany(c => c.Alarms)  // المستخدم العادي يملك عدة إنذارات
                   .HasForeignKey(a => a.CasualUserID);  

            // تحديد أن CasualUserID مطلوب (Not Nullable)
            builder.Property(a => a.CasualUserID)
                   .IsRequired();
        }
    }
}
