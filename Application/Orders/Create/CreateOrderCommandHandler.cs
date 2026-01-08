using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Orders.Create;

public class CreateOrderCommandHandler(ICreateRepository<Order> repository) : IRequestHandler<CreateOrderCommand>
{
	public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
	{
		//var createRequest = command.Request;
		//await ValidateRequest(createRequest);
		//Order document = createRequest.Types switch
		//{
		//	OrderTypes.Sale => new SaleOrder(),
		//	OrderTypes.Purchase => new PurchaseOrder(),
		//	_ => throw new NotImplementedException("Order type not supported yet")
		//};

		//document.BPCode = createRequest.BPCode;
		//document.CreateDate = DateTime.UtcNow;
		//document.CreatedBy = 0; // ToDo: Get user from context

		//var orderLines = await CreateDocumentOrderlines(createRequest);

		//await dbContext.Orders.AddAsync(document, cancellationToken);
	}
}