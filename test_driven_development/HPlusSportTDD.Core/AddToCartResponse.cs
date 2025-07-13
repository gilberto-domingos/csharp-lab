namespace HPlusSportTDD.Core;
// Resposta ao Adicionar Ao Carrinho 
// Tipo: DTO (Objeto de Transferência de Dados)
// Representar a resposta da operação de adicionar ao carrinho.

public class AddToCartResponse
{
    public AddToCartItem[] Items { get; set; }
}