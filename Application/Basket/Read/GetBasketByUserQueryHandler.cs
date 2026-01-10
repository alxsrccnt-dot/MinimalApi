using Application.Common.Services;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Basket.Read;

public class GetBasketByUserQueryHandler(ICurrentUser currentUser, IBasketReadRepository basketReadRepository) : IRequestHandler<GetBasketByUserQuery, IEnumerable<BasketItemDto>>
{
	public async Task<IEnumerable<BasketItemDto>> Handle(GetBasketByUserQuery command, CancellationToken cancellationToken)
	{
		var items = await basketReadRepository.GetBasketByUserAsync(currentUser.Email!, cancellationToken);
		return items.Select(b => new BasketItemDto(b.Id, b.Product.Title, b.Quantity));
	}
}