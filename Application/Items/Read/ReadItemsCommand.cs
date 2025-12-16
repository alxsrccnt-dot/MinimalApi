using Application.Common;
using MediatR;

namespace Application.Items.Read;

public record ReadItemsCommand(PaginatedRequest<FilterByItemsColumn> ReadItemsRequest) : IRequest<PaginatedResultDto<ItemDto>>;