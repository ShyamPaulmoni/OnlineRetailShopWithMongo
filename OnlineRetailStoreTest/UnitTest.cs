using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OnlineRetailStore.Controllers;
using OnlineRetailStore.Models;
using OnlineRetailStore.Models.Interfaces;

namespace OnlineRetailStoreTest
{
    public class Tests
    {
        private readonly Mock<IProductServices> _productServicesMock;
        private readonly Mock<IOrderServices> _orderServicesMock;
        private List<Product> _products;
        private List<Order> _orders;
        private readonly ProductController _productController;
        private readonly OrderController _orderController;

        public Tests()
        {
            _productServicesMock = new Mock<IProductServices>();
            _productController = new ProductController(_productServicesMock.Object);
            _orderServicesMock = new Mock<IOrderServices>();
            _orderController = new OrderController(_orderServicesMock.Object);
        }

        [SetUp]
        public void Setup()
        {
            _products = new List<Product>
           {
               new Product()
               {
                   ItemId = 1,
                   ItemName = "Item_1",
                   ItemPrice = 10,
                   ItemQuantity = 36
               },
               new Product()
               {
                   ItemId = 2,
                   ItemName = "Item_2",
                   ItemPrice = 102,
                   ItemQuantity = 10
               },
               new Product()
               {
                   ItemId = 3,
                   ItemName = "Item_3",
                   ItemPrice = 40,
                   ItemQuantity = 50
               }
           };

            _orders = new List<Order>
           {
               new Order()
               {
                   OrderId = 1,
                   OrderAmount = 10,
                   OrderDate = DateTime.Now,
                   OrderQuantity = 20,
                   ProductId = 1
               }
           };
        }

        [TestCase(1)]
        public void GetProductSuccessTest(int id)
        {
            _productServicesMock.Setup(x => x.GetProduct(id))
                .Returns(_products.FirstOrDefault(product => product.ItemId == id));

            var result = _productController.GetProduct(id) as ObjectResult;

            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode.Value);
        }

        [TestCase(4)]
        public void GetProductFailTest(int id)
        {
            _productServicesMock.Setup(x => x.GetProduct(id))
                .Returns(_products.FirstOrDefault(product => product.ItemId == id));

            var result = _productController.GetProduct(id) as ObjectResult;

            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode.Value);
        }

        [TestCase(1)]
        public void GetOrderSuccessTest(int id)
        {
            _orderServicesMock.Setup(x => x.GetOrder(id))
                .Returns(_orders.FirstOrDefault(order => order.OrderId == id));

            var result = _orderController.GetOrder(id) as ObjectResult;

            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode.Value);
        }

        [TestCase(4)]
        public void GetOrderFailTest(int id)
        {
            _orderServicesMock.Setup(x => x.GetOrder(id))
                .Returns(_orders.FirstOrDefault(order => order.OrderId == id));

            var result = _orderController.GetOrder(id) as ObjectResult;

            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode.Value);
        }
    }
}