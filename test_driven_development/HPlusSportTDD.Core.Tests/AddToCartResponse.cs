namespace HPlusSportTDD.Core.Tests;
// Resposta ao Adicionar Ao Carrinho 
// Tipo: DTO (Objeto de Transferência de Dados)
// Representar a resposta da operação de adicionar ao carrinho.

internal class AddToCartResponse
{
    public AddToCartItem[] Items { get; set; }
}