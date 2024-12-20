using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MoreLife.core.Settings;

namespace MoreLife.Infrastructure.Persistence.Configurations;

public class JwtSettingsConfiguration : IEntityTypeConfiguration<JwtSettings>
{
    public void Configure(EntityTypeBuilder<JwtSettings> builder)
    {
        builder.HasKey(u => u.Secret);

        builder.Property(u => u.Issuer)
            .IsRequired();

        builder.Property(u => u.Audience)
            .IsRequired();

        builder.Property(u => u.ExpirationInMinutes)
        .IsRequired();

    }
}
