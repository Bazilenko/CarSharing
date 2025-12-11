using CarSharing.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        
        builder.Property(p => p.Amount)
               .HasPrecision(18, 2);

        
        builder.Property(p => p.Status)
               .HasConversion<string>()
               .IsRequired();

        builder.Property(p => p.PaymentMethod)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(p => p.TransactionId)
               .HasMaxLength(100);

        
        builder.HasOne(p => p.Booking)
               .WithOne(b => b.Payment)
               .HasForeignKey<Payment>(p => p.BookingId)
               .OnDelete(DeleteBehavior.Restrict); 
    }
}