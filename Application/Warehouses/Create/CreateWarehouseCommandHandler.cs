using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Warehouses.Create;

public class CreateWarehouseCommandHandler(ICreateRepository<Warehouse> repository) : IRequestHandler<CreateWarehouseCommand>
{
	public async Task Handle(CreateWarehouseCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		if (string.IsNullOrWhiteSpace(request.City))
		{
			throw new ValidationException("City must be specified.");
		}

		var warehouse = new Warehouse(request.City);

		await repository.CreateAsync(warehouse, cancellationToken);
	}
}