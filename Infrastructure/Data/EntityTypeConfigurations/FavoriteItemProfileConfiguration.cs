using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations;

internal class FavoriteItemProfileConfiguration : IEntityTypeConfiguration<FavoriteItem>
{
	public void Configure(EntityTypeBuilder<FavoriteItem> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasOne(x => x.Product)
			   .WithMany(x => x.FavoritesItem)
			   .HasForeignKey(x => x.ProductId)
			   .OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(x => x.UserFavorite)
			   .WithMany(x => x.FavoriteItems)
			   .HasForeignKey(x => x.UserFavoriteId)
			   .OnDelete(DeleteBehavior.NoAction);
	}
}