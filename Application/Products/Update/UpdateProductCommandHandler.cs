using Application.Common.Exceptions;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Update;

public class UpdateProductCommandHandler(IReadRepository<Product> readRepository, IUpdateRepository<Product> updateRepository) : IRequestHandler<UpdateProductCommand>
{
	public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var product = await readRepository.GetByIdAsync(request.Id, cancellationToken);

		if (product is null)
			throw new NotFoundException("Product not found.");

		product.Code = request.Code;
		product.Title = request.Title;
		product.Description = request.Description;
		product.Price = request.Price;
		product.CategoryId = request.CategoryId;

		await updateRepository.UpdateAsync(product, cancellationToken);
	}
}