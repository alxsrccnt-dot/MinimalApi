using MediatR;

namespace Application.Orders.Delete;

public class DeleteOrderCommandHandler() : IRequestHandler<DeleteOrderCommand>
{
	public async Task Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
	{
		
	}
}