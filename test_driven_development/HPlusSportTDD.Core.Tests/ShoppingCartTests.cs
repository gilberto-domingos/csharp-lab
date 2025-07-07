using NUnit.Framework;
// Teste no Carrinho Compras 
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

        var request1 = new AddToCartRequest()
        {
            Item = item1
        };

        var item2 = new AddToCartItem()
        {
            ArticleId = 43,
            Quantity = 10
        };

        var request2 = new AddToCartRequest()
        {
            Item = item2
        };

        var manager = new ShoppingCartManager();

        manager.AddToCart(request1);

        AddToCartResponse response = manager.AddToCart(request2);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Items, Does.Contain(item1));
        Assert.That(response.Items, Does.Contain(item2));
    }
    
    public void ShouldReturnCombinedItemsAddedToCart()
    {
        var item = new AddToCartItem()
        {
            ArticleId = 42,
            Quantity = 5
        };

        var request1 = new AddToCartRequest()
        {
            Item = item
        };

        var item2 = new AddToCartItem()
        {
            ArticleId = 43,
            Quantity = 10
        };

        var request2 = new AddToCartRequest()
        {
            Item = item2
        };

        var manager = new ShoppingCartManager();

        manager.AddToCart(request1);

        AddToCartResponse response = manager.AddToCart(request2);

        Assert.That(response, Is.Not.Null);
        Assert.That(Array.Exists(response.Items, item => item.ArticleId == 42 && item.Quantity == 10));
    }

}