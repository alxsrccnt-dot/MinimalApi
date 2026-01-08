using MediatR;

namespace Application.Orders.Delete;

public record DeleteOrderCommand(int Id) : IRequest;