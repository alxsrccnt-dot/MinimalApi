using MediatR;

namespace Application.Categories.Update;

public record UpdateCategoryCommand(UpdateCategoryRequest Request) : IRequest;