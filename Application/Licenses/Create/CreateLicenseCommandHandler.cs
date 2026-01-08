using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Licenses.Create;

public class CreateLicenseCommandHandler(ICreateRepository<License> repository) : IRequestHandler<CreateLicenseCommand>
{
	public async Task Handle(CreateLicenseCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		if (request.ExpirationDate <= DateTime.UtcNow)
		{
			throw new ValidationException("Expiration date must be in the future.");
		}

		var license = new License(request.LicensedProductId, request.ExpirationDate);

		await repository.CreateAsync(license, cancellationToken);
	}
}