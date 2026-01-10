using MediatR;

namespace Application.Basket.Read;

public record GetBasketByUserQuery() : IRequest<IEnumerable<BasketItemDto>>;