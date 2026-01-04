namespace Application.Queries.Items.Create;

public record CreateItemRequest(
	string Name,
	decimal Price,
	int QuantityInStock
);