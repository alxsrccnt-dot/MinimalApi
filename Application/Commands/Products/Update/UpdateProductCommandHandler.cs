using Application.Common.Exceptions;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Products.Update;

public class UpdateProductCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateProductCommand>
{
	public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var product = await context.Products
			.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

		if (product is null)
			throw new NotFoundException("Product not found.");

		product.Code = request.Code;
		product.Title = request.Title;
		product.Description = request.Description;
		product.Price = request.Price;
		product.CategoryId = request.CategoryId;

		// persist changes
		context.Products.Update(product);
		await context.SaveChangesAsync(cancellationToken);
	}
}