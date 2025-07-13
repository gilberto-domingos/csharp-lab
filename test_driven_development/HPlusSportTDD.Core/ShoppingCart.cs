using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Carrinho de Compras
// Tipo: Entidade
// Representa o carrinho de um usuário contendo uma lista de itens adicionados.

namespace HPlusSportTDD.Core
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public virtual List<AddToCartItem> Items { get; set; }
    }
}
