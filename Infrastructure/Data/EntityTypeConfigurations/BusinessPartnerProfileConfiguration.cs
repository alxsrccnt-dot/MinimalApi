using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class BusinessPartnerProfileConfiguration : IEntityTypeConfiguration<BusinessPartner>
{
	public void Configure(EntityTypeBuilder<BusinessPartner> builder)
	{
		builder.HasKey(x => x.BPCode);

		builder.Property(x => x.BPCode)
			   .HasMaxLength(128);

		builder.Property(x => x.BPName)
			   .HasMaxLength(254)
			   .IsRequired();

		builder.Property(x => x.BPType)
			   .HasMaxLength(1)
			   .IsRequired();

		builder.Property(x => x.Active)
			   .HasDefaultValue(true);

		builder.HasOne(x => x.Type)
			   .WithMany(x => x.BusinessPartners)
			   .HasForeignKey(x => x.BPType)
			   .OnDelete(DeleteBehavior.Restrict);
	}
}