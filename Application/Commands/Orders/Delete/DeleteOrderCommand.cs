using MediatR;

namespace Application.Commands.Orders.Delete;

public record DeleteOrderCommand(int Id) : IRequest;