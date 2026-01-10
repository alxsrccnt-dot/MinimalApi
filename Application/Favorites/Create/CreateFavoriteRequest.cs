namespace Application.Favorites.Create;

public class CreateFavoriteRequest(string userEmail, int productId)
{
	public string UserEmail { get; init; } = userEmail;
	public int ProductId { get; init; } = productId;
}