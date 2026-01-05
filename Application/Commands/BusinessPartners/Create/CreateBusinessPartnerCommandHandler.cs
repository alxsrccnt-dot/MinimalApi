using Application.Commands.BusinessPartners.Create;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.BusinessPartners.Create;

public class CreateBusinessPartnerCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateBusinessPartnerCommand>
{
	public async Task Handle(CreateBusinessPartnerCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		if (string.IsNullOrWhiteSpace(request.Code) || string.IsNullOrWhiteSpace(request.Name))
			throw new ValidationException("Business partner code and name must be specified.");

		var bp = new BusinessPartner
		{
			Code = request.Code,
			Name = request.Name
		};

		await context.BusinessPartners.AddAsync(bp, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);
	}
}