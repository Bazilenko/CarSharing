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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Make).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Model).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LicensePlate).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.LicensePlate).IsUnique(); 

            
            builder.Property(c => c.PricePerDay).HasPrecision(18,2);

            builder.Property(c => c.Status).HasConversion<string>();
            builder.Property(c => c.Transmission).HasMaxLength(20);

            builder.HasOne(c => c.Host)
                   .WithMany(u => u.OwnedCars)
                   .HasForeignKey(c => c.HostId)
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
