using CarSharing.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
{
    public void Configure(EntityTypeBuilder<CarImage> builder)
    {
        builder.HasKey(img => img.Id);

        builder.Property(img => img.ImageUrl)
               .IsRequired()
               .HasMaxLength(500);

        
        builder.HasOne(img => img.Car)
               .WithMany(c => c.Images)
               .HasForeignKey(img => img.CarId)
               .OnDelete(DeleteBehavior.Cascade); 
    }
}