using Application.Common.Enums;

namespace Application.Documents.Create;

public record CreateDocumentRequest(OrderTypes Types, string BPCode, IEnumerable<string> ItemsId);