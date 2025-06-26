namespace HPlusSportTDD.Core.Tests;

class ShoppingCartTests
{
    [SetUp]
    public void SetUp()
    {
        
    }

    [Test]
    public void ShouldReturnArticleAddedToCart()
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

        Assert.NotNull(response);
        Assert.Contains(item, response.Items);
    }
}