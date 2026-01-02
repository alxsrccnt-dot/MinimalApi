using Domain.Entities.Product;
using Domain.Enums;
using Infrastructure.Data;
using MediatR;

namespace Application.Commands.Products.Create;

public class CreateProductCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateProductCommand>
{
	public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		var raitings = new List<Rating>
		{
			new Rating { Score = RaitingScoreValues.Excellent, Comment = "Excellent product!" },
			new Rating { Score = RaitingScoreValues.Good, Comment = "Very good, but could be improved." }
		};
		var physicalProduct = new PhysicalProduct
		{
			Code = "PP-1",
			Title = "New Physical Product",
			Description = "Description of the new physical product",
			Price = 150,
			Ratings = raitings,
			IsActive = true
		};

		var wherehouse = new Warehouse
		{
			City = "New York"
		};

		var wherehouseInventory = new Inventory
		{
			Quantity = 100,
			PhysicalProduct = physicalProduct,
			Warehouse = wherehouse
		};

		var licenses = new List<License>
		{
			new License (DateTime.UtcNow.AddYears(1)),
			new License (DateTime.UtcNow.AddYears(1))
		};

		var licensedProduct = new LicensedProduct
		{
			Code = "LP-1",
			Title = "New Licensed Product",
			Description = "Description of the new licensed product",
			Price = 200,
			Licenses = licenses,
			IsActive = true
		};

		await context.Warehouses.AddAsync(wherehouse, cancellationToken);
		await context.Products.AddAsync(physicalProduct, cancellationToken);
		await context.Products.AddAsync(licensedProduct, cancellationToken);
		await context.Inventories.AddAsync(wherehouseInventory, cancellationToken);
		await context.SaveChangesAsync();
	}
}