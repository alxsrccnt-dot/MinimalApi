using Application.Commands.Categories.Common;

namespace Application.Commands.Categories.Create;

public class CreateCategoryRequest(string title) : CreateOrUpdateCategoryRequest(title) { }