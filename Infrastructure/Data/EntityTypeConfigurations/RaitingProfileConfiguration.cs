using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class RaitingProfileConfiguration : IEntityTypeConfiguration<Rating>
{
	public void Configure(EntityTypeBuilder<Rating> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Comment)
			   .HasMaxLength(256)
			   .IsRequired();

		builder.HasOne(x => x.Product)
			   .WithMany(x => x.Ratings)
			   .HasForeignKey(x => x.ProductId)
			   .IsRequired();
	}
}