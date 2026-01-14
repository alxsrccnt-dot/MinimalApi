using Domain.Enums;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class ProductReadRepositroy(ApplicationDbContext context) : IProductReadRepositroy
{
	public async Task<int> GetTotalAmountOfProductsAsync(int productId, ProductType productType, CancellationToken cancellationToken = default)
		=> productType switch
		{
			ProductType.Physical => await context.Inventories
				.AsNoTracking()
				.Where(i => i.PhysicalProductId == productId)
				.SumAsync(i => i.Quantity, cancellationToken),
			ProductType.Licentied => await context.Licenses
				.AsNoTracking()
				.Where(p => p.LicensedProductId == productId)
				.CountAsync(cancellationToken),
			_ => throw new ArgumentOutOfRangeException(nameof(productType), "Invalid product type")
		};

	public async Task<int> GetTotalAmountOfProductsAsync(List<int> productIds, CancellationToken cancellationToken = default)
	{
		var products = await context.Products
			.AsNoTracking()
			.Where(p => productIds.Contains(p.Id))
			.ToListAsync(cancellationToken);

		return 1;
	}
}