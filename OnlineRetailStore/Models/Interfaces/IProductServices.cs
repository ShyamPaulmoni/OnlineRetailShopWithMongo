using System.Collections.Generic;
using OnlineRetailStore.ViewModels;

namespace OnlineRetailStore.Models.Interfaces
{
    public interface IProductServices
    {
        /// <summary>
        /// Get all the products
        /// </summary>
        /// <returns></returns>
        List<Product> GetProductList();

        /// <summary>
        /// Get product for the given productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetProduct(int productId);

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        ProductViewModel AddProduct(Product productModel);

        /// <summary>
        /// Delete a product from table
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        ProductViewModel DeleteProduct(int productId);

        /// <summary>
        /// Update a product 
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        ProductViewModel UpdateProduct(Product productModel);
    }
}
