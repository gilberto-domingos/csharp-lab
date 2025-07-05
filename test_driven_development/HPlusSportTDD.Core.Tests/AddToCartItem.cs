namespace HPlusSportTDD.Core.Tests;
// Item Adicionar Ao Carrinho 
// Tipo: Objeto de Valor / DTO
// Representar um item que será adicionado ao carrinho.

internal class AddToCartItem
{
    public int ArticleId { get; init; }
    public int Quantity { get; set; }

    public AddToCartItem()
    {
        
    }
}