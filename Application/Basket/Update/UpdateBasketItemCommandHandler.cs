using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Basket.Update;

public class UpdateBasketItemCommandHandler(IBasketReadRepository basketReadRepository,
	IUpdateRepository<BasketInformation> updateRepository,
	IProductReadRepositroy productReadRepositroy,
	IDeleteRepository<BasketInformation> deleteRepository) : IRequestHandler<UpdateBasketItemCommand>
{
	public async Task Handle(UpdateBasketItemCommand command, CancellationToken cancellationToken)
	{
		var r = command.Request;

		var existing = await basketReadRepository.GetBasketInformationAsync(r.UserEmail, r.ProductId, cancellationToken);

		if (existing is null)
			throw new NotFoundException("Basket item not found.");

		if (r.Quantity == 0)
		{
			await deleteRepository.DeleteAsync(existing, cancellationToken);
		}
		else
		{
			var productType = existing.Product is PhysicalProduct
				? ProductType.Physical
				: existing.Product is LicensedProduct ? ProductType.Licentied
					: throw new Exception("Invalid product type.");

			var totalAvailable = await productReadRepositroy.GetTotalAmountOfProductsAsync(r.ProductId, productType, cancellationToken);
			if (r.Quantity > totalAvailable)
				throw new Exception("Insufficient product quantity available.");
			existing.Quantity += r.Quantity;
			await updateRepository.UpdateAsync(existing);
		}
	}
}