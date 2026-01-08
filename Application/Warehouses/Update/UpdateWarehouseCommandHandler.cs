using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Warehouses.Update;

public class UpdateWarehouseCommandHandler(IReadRepository<Warehouse> readRepository, IUpdateRepository<Warehouse> updateRepository) : IRequestHandler<UpdateWarehouseCommand>
{
	public async Task Handle(UpdateWarehouseCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var warehouse = await readRepository.GetByIdAsync(request.Id, cancellationToken);
		if (warehouse is null)
			throw new ValidationException("Warehouse not found.");

		if (string.IsNullOrWhiteSpace(request.City))
			throw new ValidationException("City must be specified.");

		warehouse.City = request.City;

		await updateRepository.UpdateAsync(warehouse, cancellationToken);
	}
}