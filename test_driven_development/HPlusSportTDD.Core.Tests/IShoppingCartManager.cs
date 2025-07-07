namespace HPlusSportTDD.Core.Tests;

public interface IShoppingCartManager
{
    public AddToCartResponse AddToCart(AddToCartRequest request);
    public AddToCartItem[] GetToCart();
}