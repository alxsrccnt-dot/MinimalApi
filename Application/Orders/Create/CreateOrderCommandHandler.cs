using Application.Common.Services;
using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Orders.Create;

public class CreateOrderCommandHandler(ICurrentUser currentUser,
	IBasketReadRepository basketReadRepository,
	ICreateRepository<Order> repository) : IRequestHandler<CreateOrderCommand>
{
	public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;
		var currentUserEmail = currentUser.Email!;
		var activeProductsInBasket = await basketReadRepository.GetSelectedProductInBasketAsync(currentUserEmail, cancellationToken);

		var orderlines = GenereteOrderlinesWithBasketProducts(activeProductsInBasket, currentUserEmail);

		var order = new Order(request.BussinesPartenerId, orderlines)
		{
			CreatedBy = currentUserEmail,
			CreateAt = DateTime.UtcNow
		};
	}

	private List<OrderLine> GenereteOrderlinesWithBasketProducts(IEnumerable<CheckoutBasketProduct> activeProductsInBasket, string userEmail)
	{
		var createdAt = DateTime.UtcNow;
		var orderlines = new List<OrderLine>();
		foreach (var product in activeProductsInBasket)
			switch (product.Type)
			{
				case ProductType.Physical:
					orderlines.Add(new PhysicalOrderline
					{
						PhysicalProductId = product.ProductId,
						Quantity = product.Quantity,
						CreateAt = createdAt,
						CreatedBy = userEmail
					});
					break;
				case ProductType.Licentied:
					orderlines.Add(new LicensedOrderLine
					{
						LicensedProductID = product.ProductId,
						CreateAt = createdAt,
						CreatedBy = userEmail
					});
					break;
			}

		return orderlines;
	}
}