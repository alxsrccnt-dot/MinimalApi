using MediatR;

namespace Application.Commands.Orders.Create;

public record CreateOrderCommand(Guid OrderId) : IRequest;