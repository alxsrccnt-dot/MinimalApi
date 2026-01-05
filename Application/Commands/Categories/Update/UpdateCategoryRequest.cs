using Application.Commands.Categories.Common;

namespace Application.Commands.Categories.Update;

public class UpdateCategoryRequest(int Id, string title) : CreateOrUpdateCategoryRequest(title)
{
	public int Id { get; init; } = Id;
}