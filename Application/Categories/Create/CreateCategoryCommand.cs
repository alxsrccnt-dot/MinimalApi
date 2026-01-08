using MediatR;

namespace Application.Categories.Create;

public record CreateCategoryCommand(CreateCategoryRequest Request) : IRequest;