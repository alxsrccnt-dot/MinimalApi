using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class OrderLineProfileConfiguration : IEntityTypeConfiguration<OrderLine>
{
	public void Configure(EntityTypeBuilder<OrderLine> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.CreatedBy)
			   .HasMaxLength(100)
			   .IsRequired();

		builder.HasDiscriminator<string>("OrderLineType")
			   .HasValue<LicensedOrderLine>("LicensedOrderLine")
			   .HasValue<PhysicalOrderline>("PhysicalOrderline");	

		builder.HasOne(x => x.Order)
			   .WithMany(x => x.OrderLines)
			   .HasForeignKey(x => x.OrderID)
			   .OnDelete(DeleteBehavior.NoAction);
	}
}