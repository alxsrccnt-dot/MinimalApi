using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class BasketReadRepository(ApplicationDbContext context) : IBasketReadRepository
{
	public async Task<BasketInformation?> GetBasketInformationAsync(string userEmail, int productId, CancellationToken cancellationToken = default)
		=> await context.BasketInformations.FirstOrDefaultAsync (b => b.UserEmail == userEmail && b.ProductId == productId, cancellationToken);

	public async Task<List<BasketInformation>> GetBasketByUserAsync(string userEmail, CancellationToken cancellationToken)
		=> await context.BasketInformations.AsNoTracking().Include(b => b.Product).Where(b => b.UserEmail == userEmail).ToListAsync(cancellationToken);

	public async Task<IEnumerable<Product>> GetSelectedProductInBasketAsync(string userEmail, CancellationToken cancellationToken)
		 => await context.BasketInformations
				.AsNoTracking()
				.Include(b => b.Product)
				.Where(b => b.UserEmail == userEmail && b.Status == BasketItemStatus.Selected)
				.Select(b => b.Product)
				.ToListAsync(cancellationToken);
}
