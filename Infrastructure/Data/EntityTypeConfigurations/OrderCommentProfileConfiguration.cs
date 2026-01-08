using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class OrderCommentProfileConfiguration : IEntityTypeConfiguration<OrderComment>
{
	public void Configure(EntityTypeBuilder<OrderComment> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.CreatedBy)
			   .HasMaxLength(50)
			   .IsRequired();
		builder.Property(x => x.CreateAt)
			   .IsRequired();

		builder.Property(x => x.Comment)
			   .IsRequired();

		builder.Property(x => x.CreatedBy)
			   .IsRequired();

		builder.HasOne(x => x.Order)
			   .WithOne(x => x.Comment)
			   .HasForeignKey<OrderComment>(x => x.OrderID)
			   .OnDelete(DeleteBehavior.NoAction);
	}
}