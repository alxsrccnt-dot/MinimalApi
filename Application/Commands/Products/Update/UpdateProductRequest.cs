using Application.Commands.Products.Common;

namespace Application.Commands.Products.Update;

public class UpdateProductRequest(int id, string code, string title, string description, int price, int categoryId)
	: BaseCreateOrUpdateProductRequest(code, title, description, price, categoryId)
{
	public int Id { get; init; } = id;
}