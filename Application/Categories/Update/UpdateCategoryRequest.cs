using Application.Categories.Common;

namespace Application.Categories.Update;

public class UpdateCategoryRequest(int Id, string title) : CreateOrUpdateCategoryRequest(title)
{
	public int Id { get; init; } = Id;
}