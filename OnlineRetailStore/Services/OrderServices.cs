using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using OnlineRetailStore.Models;
using OnlineRetailStore.Models.Interfaces;
using OnlineRetailStore.Repository.Interfaces;
using OnlineRetailStore.ViewModels;

namespace OnlineRetailStore.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IServiceProvider _serviceProvider;

        public OrderServices(IServiceProvider serviceProvider, IOrderRepository orderRepository)
        {
            _serviceProvider = serviceProvider;
            _orderRepository = orderRepository;
        }

        public List<Order> GetOrderList()
        {
            return _orderRepository.GetAll();
        }

        public Order GetOrder(int orderId)
        {
            return _orderRepository.Get(orderId);
        }

        public ProductViewModel AddOrder(Order orderModel)
        {
            var responseViewModel = new ProductViewModel();
            try
            {
                var productServices = _serviceProvider.GetRequiredService<IProductServices>();
                var product = productServices.GetProduct(orderModel.ProductId);

                if (product == null)
                {
                    responseViewModel.Message = "Ordered product with id: " + orderModel.ProductId +
                                                " doesn't exists in the store.";
                    responseViewModel.IsSuccess = false;
                }
                else if (product.ItemQuantity < orderModel.OrderQuantity)
                {
                    responseViewModel.Message =
                        "Ordered quantity of product is not available in the store. \\n Available Quantity = " +
                        product.ItemQuantity;
                    responseViewModel.IsSuccess = false;
                }
                else
                {
                    orderModel.OrderAmount = orderModel.OrderQuantity * product.ItemPrice;
                    _orderRepository.Add(orderModel);
                    product.ItemQuantity -= orderModel.OrderQuantity;
                    productServices.UpdateProduct(product);
                    responseViewModel.IsSuccess = true;
                    responseViewModel.Message = "Order with id: " + orderModel.OrderId + " is placed.";
                }
            }
            catch (Exception e)
            {
                responseViewModel.IsSuccess = false;
                responseViewModel.Message = e.Message;
            }

            return responseViewModel;
        }

        public ProductViewModel DeleteOrder(int orderId)
        {
            var responseViewModel = new ProductViewModel();
            try
            {
                var order = GetOrder(orderId);

                if (order == null)
                {
                    responseViewModel.Message = "No order is available with an order id: " + orderId;
                    responseViewModel.IsSuccess = false;
                }
                else
                {
                    var productServices = _serviceProvider.GetRequiredService<IProductServices>();
                    var product = productServices.GetProduct(order.ProductId);

                    _orderRepository.Delete(order);
                    product.ItemQuantity += order.OrderQuantity;
                    productServices.UpdateProduct(product);
                    responseViewModel.IsSuccess = true;
                    responseViewModel.Message = "Order with id: " + orderId + " is deleted.";
                }
            }
            catch (Exception e)
            {
                responseViewModel.IsSuccess = false;
                responseViewModel.Message = e.Message;
            }

            return responseViewModel;
        }
    }
}
