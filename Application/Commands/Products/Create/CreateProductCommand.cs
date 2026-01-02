using MediatR;

namespace Application.Commands.Products.Create;

public record CreateProductCommand() : IRequest;