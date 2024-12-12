using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MoreLife.core.Entities;

namespace MoreLife.Infrastructure.Persistence.Configurations;

public class DonationConfiguration : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Date)
            .IsRequired();

        builder.Property(d => d.Quantity)
            .IsRequired();
    }
}