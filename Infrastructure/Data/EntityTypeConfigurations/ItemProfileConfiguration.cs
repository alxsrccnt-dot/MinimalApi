using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class ItemProfileConfiguration : IEntityTypeConfiguration<Item>
{
	public void Configure(EntityTypeBuilder<Item> builder)
	{
		builder.HasKey(x => x.ItemCode);
		builder.Property(x => x.ItemCode)
			   .HasMaxLength(128);

		builder.Property(x => x.ItemName)
				   .HasMaxLength(254)
				   .IsRequired();

		builder.Property(x => x.Active)
				   .HasDefaultValue(true);
	}
}