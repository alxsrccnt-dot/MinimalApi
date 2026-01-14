using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class BasketReadRepository(ApplicationDbContext context) : IBasketReadRepository
{
	public async Task<BasketInformation?> GetBasketInformationAsync(string userEmail, int productId, CancellationToken cancellationToken = default)
		=> await context.BasketInformations.FirstOrDefaultAsync (b => b.UserEmail == userEmail && b.ProductId == productId, cancellationToken);

	public async Task<List<BasketInformation>> GetBasketByUserAsync(string userEmail, CancellationToken cancellationToken)
		=> await context.BasketInformations.AsNoTracking().Include(b => b.Product).Where(b => b.UserEmail == userEmail).ToListAsync(cancellationToken);

	public async Task<IEnumerable<CheckoutBasketProduct>> GetSelectedProductInBasketAsync(string userEmail, CancellationToken cancellationToken)
	{
		var basketProducts = new List<CheckoutBasketProduct>();
		var basketInformations = context.BasketInformations
				.AsNoTracking()
				.Include(b => b.Product)
				.Where(b => b.UserEmail == userEmail && b.Status == BasketItemStatus.Selected);

		foreach (var item in basketInformations)
			if (item.Product is PhysicalProduct physicalProduct)
				basketProducts.Add(new CheckoutBasketProduct(item.ProductId, ProductType.Physical, item.Product.Price, item.Quantity));
			else if (item.Product is LicensedProduct licensedProduct)
				basketProducts.Add(new CheckoutBasketProduct(item.ProductId, ProductType.Licentied, item.Product.Price, 1));
			else
				throw new Exception("Invalid product");

		return basketProducts;
	}
}
