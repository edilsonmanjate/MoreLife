using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using MoreLife.core.Entities;

namespace MoreLife.Infrastructure.Persistence.Configuration;

public class DonatorConfiguration : IEntityTypeConfiguration<Donator>
{
    public void Configure(EntityTypeBuilder<Donator> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsOne(d => d.Address, a =>
        {
            a.Property(ad => ad.Street).IsRequired().HasMaxLength(200);
            a.Property(ad => ad.City).IsRequired().HasMaxLength(100);
            a.Property(ad => ad.State).IsRequired().HasMaxLength(100);
            a.Property(ad => ad.PostalCode).IsRequired().HasMaxLength(20);
        });

        builder.HasMany(d => d.Donations)
            .WithOne(d => d.Donator)
            .HasForeignKey(d => d.DonatorId);
    }
}
