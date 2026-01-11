namespace Application.Favorites.Create;

public class CreateFavoriteRequest(Guid collectionId, int productId)
{
	public Guid CollectionId { get; init; } = collectionId;
	public int ProductId { get; init; } = productId;
}