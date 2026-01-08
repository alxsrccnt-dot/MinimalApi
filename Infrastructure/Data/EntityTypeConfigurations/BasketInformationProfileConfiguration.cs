using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class BasketInformationProfileConfiguration : IEntityTypeConfiguration<BasketInformation>
{
	public void Configure(EntityTypeBuilder<BasketInformation> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.CreatedBy)
			   .HasMaxLength(50)
			   .IsRequired();
		builder.Property(x => x.CreateAt)
			   .IsRequired();

		builder.HasOne(x => x.Product)
			   .WithMany(x => x.BasketsInformation)
			   .HasForeignKey(x => x.ProductId)
			   .OnDelete(DeleteBehavior.NoAction);

		builder.Property(x => x.UserEmail)
			   .HasMaxLength(100)
			   .IsRequired();
		builder.HasIndex(x => x.UserEmail);
	}
}