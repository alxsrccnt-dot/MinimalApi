using MediatR;

namespace Application.Basket.Create;

public record CreateBasketItemCommand(CreateBasketItemRequest Request) : IRequest;