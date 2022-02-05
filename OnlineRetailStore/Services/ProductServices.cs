using System;
using System.Collections.Generic;
using OnlineRetailStore.Models;
using OnlineRetailStore.Models.Interfaces;
using OnlineRetailStore.Repository.Interfaces;
using OnlineRetailStore.ViewModels;

namespace OnlineRetailStore.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductViewModel AddProduct(Product productModel)
        {
            var responseViewModel = new ProductViewModel();
            try
            {
                if (GetProduct(productModel.ItemId) != null)
                {
                    responseViewModel.Message = "Product with id: " + productModel.ItemId +
                                                " already exists in the repository, use \"update product\" instead.";
                    responseViewModel.IsSuccess = false;
                }
                else
                {
                    _productRepository.Add(productModel);
                    responseViewModel.IsSuccess = true;
                    responseViewModel.Message = "Product with id: " + productModel.ItemId + " is added.";
                }
            }
            catch (Exception e)
            {
                responseViewModel.IsSuccess = false;
                responseViewModel.Message = e.Message;
            }

            return responseViewModel;
        }

        public ProductViewModel DeleteProduct(int productId)
        {
            var responseViewModel = new ProductViewModel();
            try
            {
                var product = GetProduct(productId);
                if (product == null)
                {
                    responseViewModel.Message = "Can't find the Product with id: " + productId;
                    responseViewModel.IsSuccess = false;
                }
                else
                {
                    _productRepository.Delete(product);
                    responseViewModel.IsSuccess = true;
                    responseViewModel.Message = "Product with id: " + productId + " is deleted.";
                }
            }
            catch (Exception e)
            {
                responseViewModel.IsSuccess = false;
                responseViewModel.Message = e.Message;
            }

            return responseViewModel;
        }

        public Product GetProduct(int productId)
        {
            return _productRepository.Get(productId);
        }

        public List<Product> GetProductList()
        {
            return _productRepository.GetAll();
        }

        public ProductViewModel UpdateProduct(Product productModel)
        {
            var responseViewModel = new ProductViewModel();
            try
            {
                var product = GetProduct(productModel.ItemId);
                if (product == null)
                {
                    _productRepository.Add(productModel);
                    responseViewModel.IsSuccess = true;
                    responseViewModel.Message = "Product with id: " + productModel.ItemId + " is added.";
                }
                else
                {
                    product.ItemName = productModel.ItemName;
                    product.ItemPrice = productModel.ItemPrice;
                    product.ItemQuantity = productModel.ItemQuantity;

                    _productRepository.Update(product);

                    responseViewModel.IsSuccess = true;
                    responseViewModel.Message = "Product with id: " + productModel.ItemId + " is updated.";
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
