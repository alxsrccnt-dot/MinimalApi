using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Basket.Create;

public class CreateBasketItemCommandHandler(IBasketReadRepository basketReadRepository,
	IUpdateRepository<BasketInformation> updateRepository,
	ICreateRepository<BasketInformation> createRepository,
	IDeleteRepository<BasketInformation> deleteRepository) : IRequestHandler<CreateBasketItemCommand>
{
	public async Task Handle(CreateBasketItemCommand command, CancellationToken cancellationToken)
	{
		var r = command.Request;

		var existing = await basketReadRepository.GetBasketInformationAsync(r.UserEmail, r.ProductId, cancellationToken);

		if (existing is null)
		{
			var basketInformation = new BasketInformation(r.UserEmail, r.ProductId, r.Quantity);
			await createRepository.CreateAsync(basketInformation, cancellationToken);
		}
		else
		{
			if (r.Quantity == 0)
				await deleteRepository.DeleteAsync(existing, cancellationToken);

			existing.Quantity += r.Quantity;
			await updateRepository.UpdateAsync(existing);
		}
	}
}