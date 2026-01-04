using Application.Commands.Products.Common;

namespace Application.Commands.Products.Update;

public class UpdateProductRequest : BaseCreateOrUpdateProductRequest
{
	public int Id { get; init; }
}