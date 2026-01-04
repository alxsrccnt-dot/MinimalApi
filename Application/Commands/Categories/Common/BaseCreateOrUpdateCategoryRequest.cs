namespace Application.Commands.Categories.Common;

public class BaseCreateOrUpdateCategoryRequest(string title)
{
	public string Title { get; set; } = title;
}