using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class SaleOrderLineCommentProfileConfiguration : IEntityTypeConfiguration<SaleOrderLineComment>
{
	public void Configure(EntityTypeBuilder<SaleOrderLineComment> builder)
	{
		builder.HasKey(x => x.CommentLineID);

		builder.Property(x => x.Comment)
			   .IsRequired();

		builder.HasOne(x => x.SaleOrder)
			   .WithMany(x => x.Comments)
			   .HasForeignKey(x => x.DocID);

		builder.HasOne(x => x.Line)
			   .WithMany(x => x.Comments)
			   .HasForeignKey(x => x.LineID);
	}
}