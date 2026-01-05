using MediatR;

namespace Application.Commands.Categories.Update;

public record UpdateCategoryCommand(UpdateCategoryRequest Request) : IRequest;