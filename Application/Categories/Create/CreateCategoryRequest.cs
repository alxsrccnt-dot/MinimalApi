using Application.Categories.Common;

namespace Application.Categories.Create;

public class CreateCategoryRequest(string title) : CreateOrUpdateCategoryRequest(title) { }