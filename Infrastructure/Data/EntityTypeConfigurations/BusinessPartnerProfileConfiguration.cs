using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class BusinessPartnerProfileConfiguration : IEntityTypeConfiguration<BusinessPartner>
{
	public void Configure(EntityTypeBuilder<BusinessPartner> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Code)
			   .HasMaxLength(128)
			   .IsRequired();
		builder.HasIndex(x => x.Code);

		builder.Property(x => x.Name)
			   .HasMaxLength(254)
			   .IsRequired();
	}
}