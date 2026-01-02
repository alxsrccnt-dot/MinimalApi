using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class LicensedOrderLineProfileConfiguration : IEntityTypeConfiguration<LicensedOrderLine>
{
	public void Configure(EntityTypeBuilder<LicensedOrderLine> builder)
	{
		builder.HasOne(x => x.LicensedProduct)
			   .WithMany(x => x.LicensedOrderLines)
			   .HasForeignKey(x => x.LicensedProductID);
	}
}