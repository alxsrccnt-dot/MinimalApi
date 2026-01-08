using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
	internal DbSet<BusinessPartner> BusinessPartners { get; set; }

	internal DbSet<License> Licenses { get; set; }
	internal DbSet<Product> Products { get; set; }
	internal DbSet<Category> Categories { get; set; }
	internal DbSet<Rating> Raitings { get; set; }
	internal DbSet<Warehouse> Warehouses { get; set; }
	internal DbSet<Inventory> Inventories { get; set; }

	internal DbSet<UserFavorite> UserFavorites { get; set; }
	internal DbSet<FavoriteItem> FavoriteItems { get; set; }
	internal DbSet<BasketInformation> BasketInformations { get; set; }
	internal DbSet<Order> Orders { get; set; }
	internal DbSet<OrderComment> OrderComments { get; set; }
	internal DbSet<OrderLine> OrderLines { get; set; }
	internal DbSet<LicensedOrderLine> PurchaseOrderLines { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}
}