using MediatR;

namespace Application.Licenses.Update;

public record UpdateLicenseCommand(UpdateLicenseRequest Request) : IRequest;