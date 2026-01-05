using System.ComponentModel.DataAnnotations;

namespace Application.Commands.Warehouses.Common;

public class CreateOrUpdateWarehouseRequest(string city)
{
	public string City { get; init; } = city;
}