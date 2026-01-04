using Application.Commands.Products.Common;
using Domain.Entities.Product;
using Infrastructure.Data;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Products.Create;

public class CreateProductCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateProductCommand>
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
		context.Products.Add(product);
		await context.SaveChangesAsync();
	}
}