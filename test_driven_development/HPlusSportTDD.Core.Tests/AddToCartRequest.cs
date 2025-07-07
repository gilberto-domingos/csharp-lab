namespace HPlusSportTDD.Core.Tests;
// Requisição para Adicionar Ao Carrinho 
// Tipo: DTO
// Representar uma requisição para adicionar um item ao carrinho.

internal class AddToCartRequest
{
    public AddToCartItem Item { get; set; }

    public AddToCartRequest()
    {
      
    }
}