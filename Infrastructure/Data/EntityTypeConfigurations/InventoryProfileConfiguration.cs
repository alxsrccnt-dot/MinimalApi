using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class InventoryProfileConfiguration : IEntityTypeConfiguration<Inventory>
{
	public void Configure(EntityTypeBuilder<Inventory> builder)
	{
		builder.HasKey(i => new { i.PhysicalProductId, i.WarehouseId });

		builder.HasOne(i => i.PhysicalProduct)
			   .WithMany(p => p.Inventories)
			   .HasForeignKey(i => i.PhysicalProductId);

		builder.HasOne(i => i.Warehouse)
			   .WithMany(w => w.Inventories)
			   .HasForeignKey(i => i.WarehouseId);
	}
}