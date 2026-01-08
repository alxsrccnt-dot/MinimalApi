using MediatR;

namespace Application.Products.Create;

public record CreateProductCommand(CreateProductRequest Request) : IRequest;