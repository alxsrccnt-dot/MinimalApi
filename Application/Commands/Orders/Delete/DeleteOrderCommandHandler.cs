using Application.Common.Exceptions;
using Infrastructure.Data;
using MediatR;

namespace Application.Commands.Orders.Delete;

public class DeleteOrderCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<DeleteOrderCommand>
{
	public async Task Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
	{
		var order = await dbContext.Orders.FindAsync(command.Id, cancellationToken);

		if (order is null)
			throw new NotFoundException($"Order with Id {command.Id} not found.");

		dbContext.Orders.Remove(order);
		await dbContext.SaveChangesAsync(cancellationToken);
	}
}