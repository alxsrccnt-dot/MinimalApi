using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IBasketReadRepository
{
	Task<BasketInformation?> GetBasketInformationAsync(string userEmail, int productId, CancellationToken cancellationToken = default);
	Task<List<BasketInformation>> GetBasketByUserAsync(string userEmail, CancellationToken cancellationToken);
	Task<IEnumerable<Product>> GetSelectedProductInBasketAsync(string userEmail, CancellationToken cancellationToken);
}