using Application.Products.Common;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Products.Create;

public class CreateProductCommandHandler(ICreateRepository<Product> repository) : IRequestHandler<CreateProductCommand>
{
	public async Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;
		Product product = request.Type switch
		{
			ProductType.Licentied => new LicensedProduct(request.Code, request.Title, request.Description, request.Price, request.CategoryId),
			ProductType.Physical => new PhysicalProduct(request.Code, request.Title, request.Description, request.Price, request.CategoryId),
			_ => throw new ValidationException("Product type must be specified.")
		};
		product.CreateAt = DateTime.UtcNow;
		product.CreatedBy = "test";//todo get user from context

		await repository.CreateAsync(product, cancellationToken);
	}
}