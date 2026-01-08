namespace Application.Categories.Common;

public class CreateOrUpdateCategoryRequest(string title)
{
	public string Title { get; init; } = title;
}