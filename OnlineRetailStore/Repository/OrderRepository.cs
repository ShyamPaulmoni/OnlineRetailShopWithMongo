using System.Collections.Generic;
using MongoDB.Driver;
using OnlineRetailStore.Context;
using OnlineRetailStore.Models;
using OnlineRetailStore.Repository.Interfaces;

namespace OnlineRetailStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderRepository(IOnlineRetailStoreDbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);

            var database = client.GetDatabase(dbSettings.DatabaseName);

            _orders = database.GetCollection<Order>(dbSettings.OrdersCollectionName);
        }

        public void Add(Order order)
        {
            _orders.InsertOne(order);
        }

        public void Delete(Order order)
        {
            _orders.DeleteOne(odr => odr.Id == order.Id);
        }

        public Order Get(int id)
        {
            return _orders.Find(odr => odr.OrderId == id).FirstOrDefault();
        }

        public List<Order> GetAll()
        {
            return _orders.Find(odr => true).ToList();
        }
    }
}
