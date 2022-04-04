using IMT_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMT_Backend.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.Username)
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(u => u.Sum)
                .IsRequired();
            builder.HasMany(u => u.Incomes)
                .WithOne(i => i.User)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
            builder.HasMany(u => u.Expenses)
                .WithOne(i => i.User)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
