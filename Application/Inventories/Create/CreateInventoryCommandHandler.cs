using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Inventories.Create;

public class CreateInventoryCommandHandler(ICreateRepository<Inventory> repository) : IRequestHandler<CreateInventoryCommand>
{
	public async Task Handle(CreateInventoryCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		if (request.Quantity < 0)
		{
			throw new ValidationException("Quantity cannot be negative.");
		}

		var inventory = new Inventory
		{
			PhysicalProductId = request.PhysicalProductId,
			WarehouseId = request.WarehouseId,
			Quantity = request.Quantity
		};
		
		await repository.CreateAsync(inventory, cancellationToken);
	}
}