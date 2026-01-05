using MediatR;

namespace Application.Commands.Licenses.Update;

public record UpdateLicenseCommand(UpdateLicenseRequest Request) : IRequest;