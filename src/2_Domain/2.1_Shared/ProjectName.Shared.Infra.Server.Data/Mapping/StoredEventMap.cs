
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjectName.Shared.Bus.Abstractions.ValueObjects;

namespace ProjectName.Shared.Infra.Server.Data.Mapping
{
    public class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.ToTable("EventStore");


        }
    }
}