using MediatR;

namespace Application.Commands.Categories.Create;

public record CreateCategoryCommand(CreateCategoryRequest Request) : IRequest;