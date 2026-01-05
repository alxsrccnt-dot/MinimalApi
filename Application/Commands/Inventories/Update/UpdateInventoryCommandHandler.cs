using Application.Commands.Inventories.Common;
using Domain.Entities.Product;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Inventories.Update;

public class UpdateInventoryCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateInventoryCommand>
{
	public async Task Handle(UpdateInventoryCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		if (request.Quantity < 0)
			throw new ValidationException("Quantity cannot be negative.");

		var inventory = await context.Inventories
			.FirstOrDefaultAsync(i => i.PhysicalProductId == request.PhysicalProductId && i.WarehouseId == request.WarehouseId, cancellationToken);

		if (inventory is null)
			throw new ValidationException("Inventory record not found.");

		inventory.Quantity = request.Quantity;

		context.Inventories.Update(inventory);
		await context.SaveChangesAsync(cancellationToken);
	}
}