using Domain.Entities;
using Domain.Entities.Orders;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
	public DbSet<BusinessPartner> BusinessPartners { get; set; }

	public DbSet<License> Licenses { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Rating> Raitings { get; set; }
	public DbSet<Warehouse> Warehouses { get; set; }
	public DbSet<Inventory> Inventories { get; set; }

	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderComment> OrderComments { get; set; }
	public DbSet<OrderLine> OrderLines { get; set; }
	public DbSet<LicensedOrderLine> PurchaseOrderLines { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}
}