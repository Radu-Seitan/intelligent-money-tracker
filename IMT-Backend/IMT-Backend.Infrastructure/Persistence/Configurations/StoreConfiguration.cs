using IMT_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMT_Backend.Infrastructure.Persistence.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Name)
                .HasMaxLength(40)
                .IsRequired();
            builder.HasOne(s => s.Image)
                .WithMany(i => i.Stores)
                .HasForeignKey(s => s.ImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
            builder.HasMany(s => s.Expenses)
                .WithOne(e => e.Store)
                .HasForeignKey(e => e.StoreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
