namespace HPlusSportTDD.Core.Tests;
// Gerenciador Carrinho Compras 
// Tipo: Classe de Domínio / Serviço
// Executar a lógica de negócios relacionada ao carrinho de compras.

internal class ShoppingCartManager
{
    private List<AddToCartItem> _shoppingCart;
    public ShoppingCartManager()
    {
        _shoppingCart = new List<AddToCartItem>();
    }

    public AddToCartResponse AddToCart(AddToCartRequest request)
    {
        _shoppingCart.Add(request.Item);
        
        return new AddToCartResponse()
        {
            Items = _shoppingCart.ToArray()
        };
    }
}