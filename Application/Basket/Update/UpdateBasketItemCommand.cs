	using MediatR;

namespace Application.Basket.Update;

public record UpdateBasketItemCommand(UpdateBasketItemRequest Request) : IRequest;