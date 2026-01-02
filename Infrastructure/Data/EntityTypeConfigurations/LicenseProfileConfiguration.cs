using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class LicenseProfileConfiguration : IEntityTypeConfiguration<License>
{
	public void Configure(EntityTypeBuilder<License> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Key)
			   .HasMaxLength(26)
			   .IsRequired();
		builder.HasIndex(x => x.Key);

		builder.Property(x => x.ExpirationDate)
			   .IsRequired();

		builder.HasOne(x => x.LicensedProduct)
			   .WithMany(x => x.Licenses)
			   .HasForeignKey(x => x.LicensedProductId)
			   .IsRequired();
	}
}