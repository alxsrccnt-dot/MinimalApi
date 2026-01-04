using Domain.Entities.Product;
using Infrastructure.Data;
using MediatR;

namespace Application.Commands.Categories.Create;

public class CreateCategoryCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateCategoryCommand>
{
	public async Task Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;
		var category = new Category(request.Title);
		category.CreateAt = DateTime.UtcNow;
		category.CreatedBy = "test";//todo get user from context
		await context.Categories.AddAsync(category);
		await context.SaveChangesAsync();
	}
}