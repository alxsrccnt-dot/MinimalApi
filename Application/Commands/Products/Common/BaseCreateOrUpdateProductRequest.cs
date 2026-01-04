namespace Application.Commands.Products.Common;

public class BaseCreateOrUpdateProductRequest
{
	public string Code { get; set; } = null!;
	public string Title { get; set; } = null!;
	public string Description { get; set; } = null!;
	public int Price { get; set; }
	public int CategoryId { get; set; }
}