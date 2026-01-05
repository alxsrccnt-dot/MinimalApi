using Application.Common.Exceptions;
using Domain.Entities.Product;
using Infrastructure.Data;
using MediatR;

namespace Application.Commands.Categories.Create;

public class CreateCategoryCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateCategoryCommand>
{
	public async Task Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		if (string.IsNullOrWhiteSpace(request.Title))
			throw new ValidationException(new List<string>()
			{
				"Category title cannot be empty."
			});

		var category = new Category(request.Title);
		category.CreateAt = DateTime.UtcNow;
		category.CreatedBy = "test";//todo get user from context

		await context.Categories.AddAsync(category, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);
	}
}