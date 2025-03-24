using Diabetes.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Diabete.Repository.Data.Configurations
{
    internal class ChatbotQuestionCasualUserConfiguration : IEntityTypeConfiguration<ChatbotQuestionCasualUser>
    {
        public void Configure(EntityTypeBuilder<ChatbotQuestionCasualUser> builder)
        {
            // تكوين العلاقة مع CasualUser باستخدام CasualUserID فقط
            builder.HasOne(qcu => qcu.CasualUser)
                   .WithMany(c => c.ChatbotQuestionCasualUsers)
                   .HasForeignKey(qcu => qcu.CasualUserID)
                   .IsRequired(); // التأكد من أن CasualUserID مطلوب

            // تكوين العلاقة مع Admin (اختيارية)
            builder.HasOne(qcu => qcu.Admin)
                   .WithMany(a => a.ChatbotQuestionCasualUsers)
                   .HasForeignKey(qcu => qcu.AdminID)
                   .IsRequired(false); // السماح بأن يكون AdminID فارغًا
        }
    }
}