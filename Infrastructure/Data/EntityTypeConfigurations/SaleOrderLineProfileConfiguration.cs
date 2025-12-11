using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class SaleOrderLineProfileConfiguration : IEntityTypeConfiguration<SaleOrderLine>
{
	public void Configure(EntityTypeBuilder<SaleOrderLine> builder)
	{
		builder.HasKey(x => x.LineID);

		builder.Property(x => x.Quantity)
			   .HasColumnType("DECIMAL(38,18)")
			   .IsRequired();

		builder.Property(x => x.ItemCode)
			   .HasMaxLength(128)
			   .IsRequired();

		builder.HasOne(x => x.SaleOrder)
			   .WithMany(x => x.Lines)
			   .HasForeignKey(x => x.DocID);

		builder.HasOne(x => x.Item)
			   .WithMany(x => x.SaleOrderLines)
			   .HasForeignKey(x => x.ItemCode);

		builder.HasOne(x => x.Creator)
			   .WithMany(x => x.CreatedSaleOrderLines)
			   .HasForeignKey(x => x.CreatedBy)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Updater)
			   .WithMany(x => x.UpdatedSaleOrderLines)
			   .HasForeignKey(x => x.LastUpdatedBy)
			   .OnDelete(DeleteBehavior.Restrict);
	}
}