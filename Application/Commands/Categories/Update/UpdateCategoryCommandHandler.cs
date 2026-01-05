using Application.Commands.Categories.Common;
using Domain.Entities.Product;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Categories.Update;

public class UpdateCategoryCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateCategoryCommand>
{
	public async Task Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
		if (category is null)
			throw new ValidationException("Category not found.");

		if (string.IsNullOrWhiteSpace(request.Title))
			throw new ValidationException("Category title cannot be empty.");

		category.Title = request.Title;

		context.Categories.Update(category);
		await context.SaveChangesAsync(cancellationToken);
	}
}