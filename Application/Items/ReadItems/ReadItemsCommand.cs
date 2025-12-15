using Application.Common;
using MediatR;

namespace Application.Items.ReadItems;

public record ReadItemsCommand(PaginatedRequest<FilterByItemsColumn> ReadItemsRequest) : IRequest<PaginatedResultDto<ItemDto>>;