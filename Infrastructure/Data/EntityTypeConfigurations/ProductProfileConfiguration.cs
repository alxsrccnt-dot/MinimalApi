using Domain.Entities.Orders;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class ProductProfileConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Code)
			.HasMaxLength(128);

		builder.Property(x => x.Title)
			.HasMaxLength(254)
			.IsRequired();

		builder.Property(x => x.Description)
			.HasColumnType("nvarchar(max)");

		builder.Property(x => x.IsActive)
			.HasDefaultValue(true);

		builder.HasDiscriminator<string>("ProductType")
			   .HasValue<LicensedProduct>("LicensedProduct")
			   .HasValue<PhysicalProduct>("PhysicalProduct");
	}
}