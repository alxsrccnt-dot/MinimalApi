using MediatR;

namespace Application.Commands.Licenses.Create;

public record CreateLicenseCommand(CreateLicenseRequest Request) : IRequest;