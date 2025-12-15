using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class PurchaseOrderLineProfileConfiguration : IEntityTypeConfiguration<PurchaseOrderLine>
{
	public void Configure(EntityTypeBuilder<PurchaseOrderLine> builder)
	{
		builder.HasOne(x => x.PurchaseOrder)
			   .WithMany(x => x.Lines)
			   .HasForeignKey(x => x.DocID);

		builder.HasOne(x => x.Item)
			   .WithMany(x => x.PurchaseOrderLines)
			   .HasForeignKey(x => x.ItemCode);

		builder.HasOne(x => x.Creator)
			   .WithMany(u => u.CreatedPurchaseOrderLines)
			   .HasForeignKey(x => x.CreatedBy)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Updater)
			   .WithMany(u => u.UpdatedPurchaseOrderLines)
			   .HasForeignKey(x => x.LastUpdatedBy)
			   .OnDelete(DeleteBehavior.Restrict);
	}
}