using MediatR;

namespace Application.Licenses.Update;

public class UpdateLicenseCommandHandler() : IRequestHandler<UpdateLicenseCommand>
{
	public async Task Handle(UpdateLicenseCommand command, CancellationToken cancellationToken)
	{
		//var request = command.Request;

		//if (request.ExpirationDate <= DateTime.UtcNow)
		//	throw new ValidationException("Expiration date must be in the future.");

		//var license = await context.Licenses.FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);
		//if (license is null)
		//	throw new ValidationException("License not found.");

		//license.ExpirationDate = request.ExpirationDate;
		//license.LicensedProductId = request.LicensedProductId;

		//context.Licenses.Update(license);
		//await context.SaveChangesAsync(cancellationToken);
	}
}