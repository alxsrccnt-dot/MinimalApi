using MediatR;

namespace Application.Commands.Orders.Create;

public record CreateOrderCommand(CreateOrderRequest Request) : IRequest;