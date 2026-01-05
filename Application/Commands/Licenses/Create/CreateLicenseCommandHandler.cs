using Application.Commands.Licenses.Common;
using Domain.Entities.Product;
using Infrastructure.Data;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Licenses.Create;

public class CreateLicenseCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateLicenseCommand>
{
	public async Task Handle(CreateLicenseCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		if (request.ExpirationDate <= DateTime.UtcNow)
		{
			throw new ValidationException("Expiration date must be in the future.");
		}

		var license = new License(request.LicensedProductId, request.ExpirationDate);

		await context.Licenses.AddAsync(license, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);
	}
}