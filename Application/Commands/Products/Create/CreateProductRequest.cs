using Application.Commands.Products.Common;

namespace Application.Commands.Products.Create;

public class CreateProductRequest : BaseCreateOrUpdateProductRequest
{
	public ProductType Type { get; set; }
}