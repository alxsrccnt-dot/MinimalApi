using Application.Common.Exceptions;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Categories.Create;

public class CreateCategoryCommandHandler(ICreateRepository<Category> repository) : IRequestHandler<CreateCategoryCommand>
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

		await repository.CreateAsync(category, cancellationToken);
	}
}