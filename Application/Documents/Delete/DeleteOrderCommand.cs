using MediatR;

namespace Application.Documents.Delete;

public record DeleteOrderCommand(int Id) : IRequest;