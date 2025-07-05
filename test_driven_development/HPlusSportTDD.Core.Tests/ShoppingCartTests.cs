using NUnit.Framework;
// Teste Carrinho Compras 
// Testar o comportamento da adição de itens ao carrinho.


namespace HPlusSportTDD.Core.Tests;

class ShoppingCartTests
{
    [SetUp]
    public void SetUp()
    {
        
    }

    [Test]
    public void ShouldReturnItemAddedToCart()
    {
        var item = new AddToCartItem()
        {
            ArticleId = 42,
            Quantity = 5
        };

        var request = new AddToCartRequest()
        {
            Item = item
        };

        var manager = new ShoppingCartManager();
        
        AddToCartResponse response = manager.AddToCart(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Items, Does.Contain(item));
    }
   
    
    [Test]
    public void ShouldReturnItemsAddedToCart()
    {
        var item1 = new AddToCartItem()
        {
            ArticleId = 42,
            Quantity = 5
        };

        var request = new AddToCartRequest()
        {
            Item = item1
        };

        var manager = new ShoppingCartManager();
        
        var item2 = new AddToCartItem()
        {
            ArticleId = 43,
            Quantity = 10
        };

        request = new AddToCartRequest()
        {
            Item = item2
        };
        
        AddToCartResponse response = manager.AddToCart(request);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Items, Does.Contain(item1));
        Assert.That(response.Items, Does.Contain(item2));
    }
}