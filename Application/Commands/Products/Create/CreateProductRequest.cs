using Application.Commands.Products.Common;

namespace Application.Commands.Products.Create;

public class CreateProductRequest(string code, string title, string description, int price, int categoryId, ProductType type)
	: BaseCreateOrUpdateProductRequest(code, title, description, price, categoryId)
{
	public ProductType Type { get; init; } = type;
}