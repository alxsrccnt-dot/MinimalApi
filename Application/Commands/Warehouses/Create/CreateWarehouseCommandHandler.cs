using Domain.Entities.Product;
using Infrastructure.Data;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Warehouses.Create;

public class CreateWarehouseCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateWarehouseCommand>
{
	public async Task Handle(CreateWarehouseCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		if (string.IsNullOrWhiteSpace(request.City))
		{
			throw new ValidationException("City must be specified.");
		}

		var warehouse = new Warehouse(request.City);

		await context.Warehouses.AddAsync(warehouse, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);
	}
}