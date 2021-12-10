using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopBridgeBackendMinimalApi.Services;

namespace ShopBridgeBackendMinimalApi.Tests
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void GetTest()
        {
            // Arrange
            var productService = new ProductService();

            // Act
            var actual = productService.Get(1);

            // Assert
            Assert.AreEqual(2, actual);
        }
    }
}
