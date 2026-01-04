using MediatR;

namespace Application.Commands.Products.Create;

public record CreateProductCommand(CreateProductRequest Request) : IRequest;