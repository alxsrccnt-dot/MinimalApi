using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class UserProfileConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(x => x.ID);
		builder.Property(x => x.ID)
			.ValueGeneratedOnAdd();

		builder.Property(p => p.FullName)
			.IsRequired()
			.HasMaxLength(1024);

		builder.Property(p => p.UserName)
			.IsRequired()
			.HasMaxLength(254);
		builder.HasIndex(e => e.UserName)
		   .IsUnique();

		builder.Property(p => p.Password)
			.IsRequired()
			.HasColumnType("nvarchar(max)");

		builder.Property(x => x.Active)
			.HasDefaultValue(true);
	}
}