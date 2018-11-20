
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjectName.DomainName.Domain.Models;
using ProjectName.DomainName.Domain.ValueObjects;

namespace ProjectName.DomainName.Infra.Server.Data.Configurations
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses")
                .HasKey(a => a.Id);

            builder.Property(a => a.Street)
                .HasColumnType("varchar(70)");
            
            builder.OwnsOne<City>(
                a => a.City,
                c =>
                {
                    c.Property(p => p.Name)
                        .HasColumnName("City")
                        .HasColumnType("varchar(50)");

                    c.Ignore(p => p.IgnoredPropertyInEntity);
                })
                .HasChangeTrackingStrategy(ChangeTrackingStrategy.Snapshot);
        }
    }
}