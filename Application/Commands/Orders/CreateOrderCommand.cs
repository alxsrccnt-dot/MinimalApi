using MediatR;

namespace Application.Commands.CreateOrder;

public record CreateOrderCommand(Guid OrderId) : IRequest;