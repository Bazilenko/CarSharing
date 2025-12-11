using CarSharing.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Type)
               .IsRequired()
               .HasMaxLength(50); 

        builder.Property(d => d.Status)
               .IsRequired()
               .HasMaxLength(20); 

        builder.Property(d => d.FileUrl)
               .IsRequired()
               .HasMaxLength(500); 

       
        builder.HasOne(d => d.User)
               .WithMany(u => u.Documents)
               .HasForeignKey(d => d.UserId)
               .OnDelete(DeleteBehavior.Cascade); 
    }
}