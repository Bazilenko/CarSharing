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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Comment).HasMaxLength(1000);
            builder.Property(r => r.Rating).IsRequired(); 

            
            builder.HasOne(r => r.Booking)
                   .WithMany(b => b.Reviews)
                   .HasForeignKey(r => r.BookingId)
                   .OnDelete(DeleteBehavior.Cascade); 

         
            builder.HasOne(r => r.Reviewer)
                   .WithMany(u => u.ReviewsWritten)
                   .HasForeignKey(r => r.ReviewerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
