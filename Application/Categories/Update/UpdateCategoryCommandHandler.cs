using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Categories.Update;

public class UpdateCategoryCommandHandler(IReadRepository<Category> readRepository, IUpdateRepository<Category> updateRepository) : IRequestHandler<UpdateCategoryCommand>
{
	public async Task Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var category = await readRepository.GetByIdAsync(request.Id, cancellationToken);
		if (category is null)
			throw new ValidationException("Category not found.");

		if (string.IsNullOrWhiteSpace(request.Title))
			throw new ValidationException("Category title cannot be empty.");

		category.Title = request.Title;

		await updateRepository.UpdateAsync(category, cancellationToken);
	}
}