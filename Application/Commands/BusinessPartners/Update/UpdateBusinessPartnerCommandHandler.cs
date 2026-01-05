using Application.Commands.BusinessPartners.Update;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.BusinessPartners.Update;

public class UpdateBusinessPartnerCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateBusinessPartnerCommand>
{
	public async Task Handle(UpdateBusinessPartnerCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var bp = await context.BusinessPartners.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
		if (bp is null)
			throw new ValidationException("Business partner not found.");

		if (string.IsNullOrWhiteSpace(request.Code) || string.IsNullOrWhiteSpace(request.Name))
			throw new ValidationException("Business partner code and name must be specified.");

		bp.Code = request.Code;
		bp.Name = request.Name;

		context.BusinessPartners.Update(bp);
		await context.SaveChangesAsync(cancellationToken);
	}
}