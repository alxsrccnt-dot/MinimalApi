using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class OrderLineProfileConfiguration : IEntityTypeConfiguration<OrderLine>
{
	public void Configure(EntityTypeBuilder<OrderLine> builder)
	{
		builder.HasKey(x => x.LineID);

		builder.HasDiscriminator<string>("OrderLineType")
			   .HasValue<PurchaseOrderLine>("PurchaseOrderLine")
			   .HasValue<SaleOrderLine>("SaleOrderLine");	

		builder.Property(x => x.Quantity)
			   .HasColumnType("DECIMAL(38,18)")
			   .IsRequired();

		builder.Property(x => x.ItemCode)
			   .HasMaxLength(128)
			   .IsRequired();
	}
}