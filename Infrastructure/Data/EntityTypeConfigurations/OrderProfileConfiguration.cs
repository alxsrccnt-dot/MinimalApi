using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class OrderProfileConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.HasKey(x => x.ID);

		builder.HasDiscriminator<string>("OrderType")
			   .HasValue<PurchaseOrder>("PurchaseOrder")
			   .HasValue<SaleOrder>("SaleOrder");

		builder.Property(x => x.BPCode)
			   .HasMaxLength(128)
			   .IsRequired();

		builder.Property(x => x.CreateDate)
			   .IsRequired();
	}
}