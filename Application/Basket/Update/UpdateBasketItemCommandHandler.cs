using Application.Common.Exceptions;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Basket.Update;

public class UpdateBasketItemCommandHandler(IBasketReadRepository basketReadRepository,
	IUpdateRepository<BasketInformation> updateRepository,
	IDeleteRepository<BasketInformation> deleteRepository) : IRequestHandler<UpdateBasketItemCommand>
{
	public async Task Handle(UpdateBasketItemCommand command, CancellationToken cancellationToken)
	{
		var r = command.Request;

		var existing = await basketReadRepository.GetBasketInformationAsync(r.UserEmail, r.ProductId, cancellationToken);

		if (existing is null)
			throw new NotFoundException("Basket item not found.");

		if (r.Quantity == 0)
			await deleteRepository.DeleteAsync(existing, cancellationToken);

		existing.Quantity += r.Quantity;
		await updateRepository.UpdateAsync(existing); 
	}
}