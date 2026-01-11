namespace Application.Favorites.Create;

public class CreateFavoritewithCollectionRequest(string title, int productId)
{
	public string Title { get; init; } = title;
	public int ProductId { get; init; } = productId;
}