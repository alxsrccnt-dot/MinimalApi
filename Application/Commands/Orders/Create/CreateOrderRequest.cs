namespace Application.Commands.Orders.Create;

public record CreateOrderRequest(string BPCode, int basketId);