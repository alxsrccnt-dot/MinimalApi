using Domain.Entities;

namespace Domain.Models;

public record BasketProduct(Product Product, int StorageQuantity);