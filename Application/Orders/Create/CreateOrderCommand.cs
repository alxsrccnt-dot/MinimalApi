using MediatR;

namespace Application.Orders.Create;

public record CreateOrderCommand(CreateOrderRequest Request) : IRequest;