using Application.Commands.Warehouses.Common;
using Domain.Entities.Product;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Warehouses.Update;

public class UpdateWarehouseCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateWarehouseCommand>
{
	public async Task Handle(UpdateWarehouseCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var warehouse = await context.Warehouses.FirstOrDefaultAsync(w => w.Id == request.Id, cancellationToken);
		if (warehouse is null)
			throw new ValidationException("Warehouse not found.");

		if (string.IsNullOrWhiteSpace(request.City))
			throw new ValidationException("City must be specified.");

		warehouse.City = request.City;

		context.Warehouses.Update(warehouse);
		await context.SaveChangesAsync(cancellationToken);
	}
}