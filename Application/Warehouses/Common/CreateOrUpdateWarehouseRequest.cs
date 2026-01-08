using System.ComponentModel.DataAnnotations;

namespace Application.Warehouses.Common;

public class CreateOrUpdateWarehouseRequest(string city)
{
	public string City { get; init; } = city;
}