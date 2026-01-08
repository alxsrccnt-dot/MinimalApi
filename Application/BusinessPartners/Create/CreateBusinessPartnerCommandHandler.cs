using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.BusinessPartners.Create;

public class CreateBusinessPartnerCommandHandler(ICreateRepository<BusinessPartner> repository) : IRequestHandler<CreateBusinessPartnerCommand>
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

		await repository.CreateAsync(bp, cancellationToken);
	}
}