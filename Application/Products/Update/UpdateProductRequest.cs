using Application.Products.Common;

namespace Application.Products.Update;

public class UpdateProductRequest(int id, string code, string title, string description, int price, int categoryId)
	: BaseCreateOrUpdateProductRequest(code, title, description, price, categoryId)
{
	public int Id { get; init; } = id;
}