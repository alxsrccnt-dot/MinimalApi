using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class UserFavoriteProfileConfiguration : IEntityTypeConfiguration<UserFavorite>
{
	public void Configure(EntityTypeBuilder<UserFavorite> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.CreatedBy)
			   .HasMaxLength(50)
			   .IsRequired();
		builder.Property(x => x.CreateAt)
			   .IsRequired();

		builder.Property(x => x.Title)
			   .HasMaxLength(100)
			   .IsRequired();

		builder.Property(x => x.UserEmail)
			   .HasMaxLength(100)
			   .IsRequired();
		builder.HasIndex(x => x.UserEmail);
	}
}