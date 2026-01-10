namespace Application.Basket.Create;

public class CreateBasketItemRequest(string userEmail, int productId, int quantity)
{
	public string UserEmail { get; init; } = userEmail;
	public int ProductId { get; init; } = productId;
	public int Quantity { get; init; } = quantity;
}