using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Contexto do Entity Framework para o Carrinho de Compras
// Tipo: Infraestrutura / DbContext
// Gerencia o acesso ao banco de dados para carrinhos e itens usando Entity Framework.

namespace HPlusSportTDD.Core
{
    public class ShoppingCartContext : DbContext
    {

        public ShoppingCartContext() : base()
        {
        }
        public ShoppingCartContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<AddToCartItem> Items { get; set; }
        public virtual DbSet<ShoppingCart> Carts { get; set; }
    }
}
