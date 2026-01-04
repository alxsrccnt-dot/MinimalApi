using Application.Commands.Categories.Common;

namespace Application.Commands.Categories.Update;

public class UpdateCategoryRequest(string title) : BaseCreateOrUpdateCategoryRequest(title)
{
	public int Id { get; set; }
	public bool IsActive { get; set; }
}