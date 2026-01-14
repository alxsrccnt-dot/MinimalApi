using Domain.Enums;

namespace Domain.Models;

public record CheckoutBasketProduct(int ProductId, ProductType Type, decimal Price, int Quantity);