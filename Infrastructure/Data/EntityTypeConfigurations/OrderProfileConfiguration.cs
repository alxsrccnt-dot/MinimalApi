using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class OrderProfileConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.CreatedBy)
			   .HasMaxLength(50)
			   .IsRequired();
		builder.Property(x => x.CreateAt)
			   .IsRequired();

		builder.HasOne(x => x.BusinessPartner)
			   .WithMany(x => x.Orders)
			   .HasForeignKey(x => x.BusinessPartnerId)
			   .OnDelete(DeleteBehavior.NoAction);
	}
}