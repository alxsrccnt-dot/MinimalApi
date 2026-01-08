using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class WarehouseProfileConfiguration : IEntityTypeConfiguration<Warehouse>
{
	public void Configure(EntityTypeBuilder<Warehouse> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.City)
			   .HasMaxLength(256)
			   .IsRequired();
	}
}