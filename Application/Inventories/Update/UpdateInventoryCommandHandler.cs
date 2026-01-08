using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Inventories.Update;

public class UpdateInventoryCommandHandler(/* readRepository, */IUpdateRepository<Inventory> updateRepository) : IRequestHandler<UpdateInventoryCommand>
{
	public async Task Handle(UpdateInventoryCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		if (request.Quantity < 0)
			throw new ValidationException("Quantity cannot be negative.");

		var inventory = new Inventory();

		if (inventory is null)
			throw new ValidationException("Inventory record not found.");

		inventory.Quantity = request.Quantity;

		await updateRepository.UpdateAsync(inventory, cancellationToken);
	}
}