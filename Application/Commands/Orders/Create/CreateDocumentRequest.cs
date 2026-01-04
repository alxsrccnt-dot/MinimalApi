using Application.Common.Enums;

namespace Application.Commands.Orders.Create;

public record CreateDocumentRequest(OrderTypes Types, string BPCode, IEnumerable<string> ItemsId);