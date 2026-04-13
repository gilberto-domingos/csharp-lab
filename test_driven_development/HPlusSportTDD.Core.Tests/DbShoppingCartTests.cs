using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using HPlusSportTDD.Core;

namespace HPlusSportTDD.Core.Tests
{
    public class DbShoppingCartTests
    {
        [Test]
        public void ShouldReturnItemInCart()
        {
            // Arrange
            var initialItems = new List<AddToCartItem>
            {
                new AddToCartItem
                {
                    ArticleId = 42,
                    Quantity = 5
                }
            };

            var mockContext = new Mock<ShoppingCartContext>();
            mockContext.Setup(ctx => ctx.Items).ReturnsDbSet(initialItems);

            var manager = new DbShoppingCartManager(mockContext.Object);

            // Act
            var items = manager.GetCart().ToList();

            // Assert
            Assert.That(items, Is.Not.Null);
            Assert.That(items.Count, Is.EqualTo(1));
            Assert.That(items[0].ArticleId, Is.EqualTo(42));
            Assert.That(items[0].Quantity, Is.EqualTo(5));
        }
    }
}