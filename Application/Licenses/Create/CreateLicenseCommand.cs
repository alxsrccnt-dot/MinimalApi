using MediatR;

namespace Application.Licenses.Create;

public record CreateLicenseCommand(CreateLicenseRequest Request) : IRequest;