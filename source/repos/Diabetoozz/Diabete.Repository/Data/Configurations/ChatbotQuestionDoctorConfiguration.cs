using Diabetes.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

internal class ChatbotQuestionDoctorConfiguration : IEntityTypeConfiguration<ChatbotQuestionDoctor>
{
    public void Configure(EntityTypeBuilder<ChatbotQuestionDoctor> builder)
    {
        builder.HasOne(p => p.Doctor)
            .WithMany(d => d.ChatbotQuestionDoctors)
            .HasForeignKey(p => p.DoctorID)
            .OnDelete(DeleteBehavior.Restrict); // منع الحذف التلقائي لتجنب التعارض

        builder.HasOne(p => p.Admin)
            .WithMany(a => a.ChatbotQuestionDoctors)
            .HasForeignKey(p => p.AdminID)
            .OnDelete(DeleteBehavior.Restrict); // منع الحذف التلقائي
    }
}
