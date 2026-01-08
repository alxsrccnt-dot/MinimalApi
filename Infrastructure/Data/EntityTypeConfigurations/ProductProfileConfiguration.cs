using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class ProductProfileConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.CreatedBy)
			   .HasMaxLength(50)
			   .IsRequired();
		builder.Property(x => x.CreateAt)
			   .IsRequired();

		builder.Property(x => x.Code)
			   .HasMaxLength(16)
			   .IsRequired();

		builder.Property(x => x.Title)
			   .HasMaxLength(254)
			   .IsRequired();

		builder.Property(x => x.Description)
			.HasColumnType("nvarchar(max)");

		builder.HasDiscriminator<string>("ProductType")
			   .HasValue<LicensedProduct>("LicensedProduct")
			   .HasValue<PhysicalProduct>("PhysicalProduct");

		builder.HasOne(x => x.Category)
			.WithMany(x => x.Products)
			.HasForeignKey(x => x.CategoryId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}