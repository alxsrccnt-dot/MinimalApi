using Domain.Entities.Product;
using Infrastructure.Data;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Inventories.Create;

public class CreateInventoryCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateInventoryCommand>
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

		await context.Inventories.AddAsync(inventory, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);
	}
}