using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class BPTypeProfileConfiguration : IEntityTypeConfiguration<BPType>
{
	public void Configure(EntityTypeBuilder<BPType> builder)
	{
		builder.HasKey(x => x.TypeCode);
		builder.Property(p => p.TypeCode)
			.HasMaxLength(1);

		builder.Property(p => p.TypeName)
			.IsRequired()
			.HasMaxLength(20);
	}
}