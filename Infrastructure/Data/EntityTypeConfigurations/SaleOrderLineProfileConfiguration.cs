using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class SaleOrderLineProfileConfiguration : IEntityTypeConfiguration<SaleOrderLine>
{
	public void Configure(EntityTypeBuilder<SaleOrderLine> builder)
	{
		builder.HasOne(x => x.SaleOrder)
			   .WithMany(x => x.Lines)
			   .HasForeignKey(x => x.DocID);

		builder.HasOne(x => x.Item)
			   .WithMany(x => x.SaleOrderLines)
			   .HasForeignKey(x => x.ItemCode);

		builder.HasOne(x => x.Creator)
			   .WithMany(u => u.CreatedSaleOrderLines)
			   .HasForeignKey(x => x.CreatedBy)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Updater)
			   .WithMany(u => u.UpdatedSaleOrderLines)
			   .HasForeignKey(x => x.LastUpdatedBy)
			   .OnDelete(DeleteBehavior.Restrict);
	}
}