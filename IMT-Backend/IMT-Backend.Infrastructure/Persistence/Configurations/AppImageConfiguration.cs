using IMT_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMT_Backend.Infrastructure.Persistence.Configurations
{
    public class AppImageConfiguration : IEntityTypeConfiguration<AppImage>
    {
        public void Configure(EntityTypeBuilder<AppImage> builder)
        {
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Content).IsRequired();
            builder.Property(t => t.Type).IsRequired();
        }
    }
}
