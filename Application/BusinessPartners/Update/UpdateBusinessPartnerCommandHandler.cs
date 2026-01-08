using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.BusinessPartners.Update;

public class UpdateBusinessPartnerCommandHandler(IReadRepository<BusinessPartner> readRepository, IUpdateRepository<BusinessPartner> updateRepository) : IRequestHandler<UpdateBusinessPartnerCommand>
{
	public async Task Handle(UpdateBusinessPartnerCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var bp = await readRepository.GetByIdAsync(request.Id, cancellationToken);
		if (bp is null)
			throw new ValidationException("Business partner not found.");

		if (string.IsNullOrWhiteSpace(request.Code) || string.IsNullOrWhiteSpace(request.Name))
			throw new ValidationException("Business partner code and name must be specified.");

		bp.Code = request.Code;
		bp.Name = request.Name;

		await updateRepository.UpdateAsync(bp, cancellationToken);
	}
}