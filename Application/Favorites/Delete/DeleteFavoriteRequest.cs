namespace Application.Favorites.Delete;

public class DeleteFavoriteRequest(string userEmail, int productId)
{
	public string UserEmail { get; init; } = userEmail;
	public int ProductId { get; init; } = productId;
}