namespace HPlusSportTDD.Core;

// Contrato do Gerenciador de Carrinho de Compras
// Tipo: Interface de Serviço
// Define as operações principais de adicionar itens e recuperar o carrinho.

public interface IShoppingCartManager
{
    public AddToCartResponse AddToCart(AddToCartRequest request);
    public AddToCartItem[] GetToCart();
}