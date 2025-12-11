using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class PurchaseOrderProfileConfiguration : IEntityTypeConfiguration<PurchaseOrder>
{
	public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
	{
		builder.HasKey(x => x.ID);

		builder.Property(x => x.BPCode)
			   .HasMaxLength(128)
			   .IsRequired();

		builder.Property(x => x.CreateDate)
			   .IsRequired();

		builder.HasOne(x => x.BusinessPartner)
			   .WithMany(x => x.PurchaseOrders)
			   .HasForeignKey(x => x.BPCode);

		builder.HasOne(x => x.Creator)
			   .WithMany(u => u.CreatedPurchaseOrders)
			   .HasForeignKey(x => x.CreatedBy)
			   .OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Updater)
			   .WithMany(u => u.UpdatedPurchaseOrders)
			   .HasForeignKey(x => x.LastUpdatedBy)
			   .OnDelete(DeleteBehavior.Restrict);
	}
}