namespace HPlusSportTDD.Core;
// Requisição para Adicionar Ao Carrinho 
// Tipo: DTO
// Representar uma requisição para adicionar um item ao carrinho.

public class AddToCartRequest
{
    public AddToCartItem Item { get; set; }

    public AddToCartRequest()
    {
      
    }
}