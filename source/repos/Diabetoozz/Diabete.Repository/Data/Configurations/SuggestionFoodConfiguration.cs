using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Diabetes.Core.Entities;

namespace Diabetes.Infrastructure.Configurations
{
    public class SuggestionFoodConfiguration : IEntityTypeConfiguration<SuggestionFood>
    {
        public void Configure(EntityTypeBuilder<SuggestionFood> builder)
        {
            builder.ToTable("SuggestionFoods");

            builder.HasKey(sf => sf.FoodID);

            builder.Property(sf => sf.FoodName).HasMaxLength(200).IsRequired();
            builder.Property(sf => sf.Description).HasMaxLength(1000);
            builder.Property(sf => sf.SuggestedBy).HasMaxLength(150);
            builder.Property(sf => sf.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired();

            builder.HasOne(sf => sf.Patient)
                .WithOne(p => p.SuggestionFood)
                .HasForeignKey<SuggestionFood>(sf => sf.PatientID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
