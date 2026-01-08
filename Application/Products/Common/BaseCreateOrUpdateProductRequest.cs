namespace Application.Products.Common;

public class BaseCreateOrUpdateProductRequest(string code, string title, string description, int price, int categoryId)
{
	public string Code { get; init; } = code;
	public string Title { get; init; } = title;
	public string Description { get; init; } = description;
	public int Price { get; init; } = price;
	public int CategoryId { get; init; } = categoryId;
}