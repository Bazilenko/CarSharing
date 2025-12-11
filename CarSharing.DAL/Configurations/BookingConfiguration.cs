using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSharing.DAL.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.TotalPrice).HasPrecision(18,2);
            builder.Property(b => b.Status).HasConversion<string>();

            builder.HasOne(b => b.Car)
                   .WithMany(c => c.Bookings)
                   .HasForeignKey(b => b.CarId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Renter)
                   .WithMany(u => u.Bookings)
                   .HasForeignKey(b => b.RenterId)
                   .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
