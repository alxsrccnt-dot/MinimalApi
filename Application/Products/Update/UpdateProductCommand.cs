using MediatR;

namespace Application.Products.Update;

public record UpdateProductCommand(UpdateProductRequest Request) : IRequest;