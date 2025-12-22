using Application.Common.Enums;
using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Entities.Orders;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Create;

public class CreateDocumentCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateDocumentCommand>
{
	public async Task Handle(CreateDocumentCommand command, CancellationToken cancellationToken)
	{
		var createRequest = command.Request;
		await ValidateRequest(createRequest);
		Order document = createRequest.Types switch
		{
			OrderTypes.Sale => new SaleOrder(),
			OrderTypes.Purchase => new PurchaseOrder(),
			_ => throw new NotImplementedException("Order type not supported yet")
		};

		document.BPCode = createRequest.BPCode;
		document.CreateDate = DateTime.UtcNow;
		document.CreatedBy = 0; // ToDo: Get user from context

		var orderLines = await CreateDocumentOrderlines(createRequest);

		await dbContext.Orders.AddAsync(document, cancellationToken);
	}

	private async Task<List<OrderLine>> CreateDocumentOrderlines(CreateDocumentRequest createRequest)
	{
		var items = await dbContext.Items
			.Where(i => i.Active)
			.Where(i => createRequest.ItemsId.Contains(i.ItemCode))
			.ToListAsync();

		var orderLines = new List<OrderLine>();
		foreach (var item in items)
			AddNewOrderLine(orderLines, createRequest.Types, item);

		return orderLines;
	}

	private void AddNewOrderLine(List<OrderLine> orderLines, OrderTypes types, Item item)
	{
		OrderLine orderLine = types switch
		{
			OrderTypes.Sale => new SaleOrderLine(),
			OrderTypes.Purchase => new PurchaseOrderLine(),
			OrderTypes.None => throw new InvalidOperationException("Order type not supported yet"),
			_ => throw new NotImplementedException("Order type not supported yet")
		};

		orderLine.ItemCode = item.ItemCode;
		orderLine.Quantity = 1; // ToDo: Get quantity from request
		orderLine.CreateDate = DateTime.UtcNow;
		orderLine.CreatedBy = 0; // ToDo: Get user from context
		orderLines.Add(orderLine);
	}

	private async Task ValidateRequest(CreateDocumentRequest request)
	{
		var businessPartners = await dbContext.BusinessPartners.FindAsync(request.BPCode);

		if (businessPartners is null)
			throw new NotFoundException("Business Partner not found");

		if (!businessPartners.Active)
			throw new InactiveException("Business Partner is inactive");

		if (businessPartners.BPType == "V" && request.Types == OrderTypes.Sale ||
			businessPartners.BPType == "S" && request.Types == OrderTypes.Purchase)
			throw new InvalidOperationException("Cannot create Purchase Order for Customer Business Partner");

		if (request.Types == OrderTypes.None)
			throw new InvalidOperationException("Cannot create a document without type");

		if (request.ItemsId.Count() == 0)
			throw new InvalidOperationException("Cannot create a document without items");
	}
}