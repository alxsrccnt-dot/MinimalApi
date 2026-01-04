using MediatR;

namespace Application.Commands.Products.Update;

public record UpdateProductCommand(UpdateProductRequest Request) : IRequest;