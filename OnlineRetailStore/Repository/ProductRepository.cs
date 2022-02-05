using System.Collections.Generic;
using MongoDB.Driver;
using OnlineRetailStore.Context;
using OnlineRetailStore.Models;
using OnlineRetailStore.Repository.Interfaces;

namespace OnlineRetailStore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(IOnlineRetailStoreDbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);

            var database = client.GetDatabase(dbSettings.DatabaseName);

            _products = database.GetCollection<Product>(dbSettings.ProductsCollectionName);
        }

        public void Add(Product product)
        {
            _products.InsertOne(product);
        }

        public void Update(Product product)
        {
            _products.ReplaceOne(pro => pro.Id == product.Id, product);
        }

        public void Delete(Product product)
        {
            _products.DeleteOne(pro => pro.Id == product.Id);
        }

        Product IProductRepository.Get(int id)
        {
            return _products.Find(pro => pro.ItemId == id).FirstOrDefault();
        }

        List<Product> IProductRepository.GetAll()
        {
            return _products.Find(pro => true).ToList();
        }
    }
}
