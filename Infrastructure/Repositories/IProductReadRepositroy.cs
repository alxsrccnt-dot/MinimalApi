using Domain.Enums;

namespace Infrastructure.Repositories;

public interface IProductReadRepositroy
{
	Task<int> GetTotalAmountOfProductsAsync(int productId, ProductType productType, CancellationToken cancellationToken = default);
}