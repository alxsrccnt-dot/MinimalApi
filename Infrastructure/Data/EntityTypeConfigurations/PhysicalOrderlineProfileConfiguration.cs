using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class PhysicalOrderlineProfileConfiguration : IEntityTypeConfiguration<PhysicalOrderline>
{
	public void Configure(EntityTypeBuilder<PhysicalOrderline> builder)
	{
		builder.HasOne(x => x.PhysicalProduct)
			   .WithMany(x => x.PhysicalOrderlines)
			   .HasForeignKey(x => x.PhysicalProductId)
			   .OnDelete(DeleteBehavior.NoAction);

		builder.Property(x => x.Quantity)
			   .IsRequired();
	}
}