using Domain.Entities;
using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
	public DbSet<User> Users { get; set; }
	public DbSet<BPType> BPTypes { get; set; }
	public DbSet<BusinessPartner> BusinessPartners { get; set; }
	public DbSet<Item> Items { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderLine> OrderLines { get; set; }
	public DbSet<SaleOrder> SaleOrders { get; set; }
	public DbSet<SaleOrderLine> SaleOrderLines { get; set; }
	public DbSet<SaleOrderLineComment> SaleOrderLineComments { get; set; }
	public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
	public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		SeedDataForTestings(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}

	private static void SeedDataForTestings(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>().HasData(
			new { ID = 1, FullName = "User 1", UserName = "U1", Password = "P1", Active = true },
			new { ID = 2, FullName = "User 2", UserName = "U2", Password = "P2", Active = false }
		);

		modelBuilder.Entity<BPType>().HasData(
			new { TypeCode = "C", TypeName = "Customer" },
			new { TypeCode = "V", TypeName = "Vendor" }
		);

		modelBuilder.Entity<BusinessPartner>().HasData(
			new { BPCode = "C0001", BPName = "Customer 1", BPType = "C", Active = true },
			new { BPCode = "C0002", BPName = "Customer 2", BPType = "C", Active = false },
			new { BPCode = "V0001", BPName = "Vendor 1", BPType = "V", Active = true },
			new { BPCode = "V0002", BPName = "Vendor 2", BPType = "V", Active = false }
		);

		modelBuilder.Entity<Item>().HasData(
			new { ItemCode = "Itm1", ItemName = "Item 1", Active = true },
			new { ItemCode = "Itm2", ItemName = "Item 2", Active = true },
			new { ItemCode = "Itm3", ItemName = "Item 3", Active = false }
		);
	}
}