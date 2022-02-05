using System.Collections.Generic;
using OnlineRetailStore.Models;

namespace OnlineRetailStore.Repository.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order Get(int id);
        List<Order> GetAll();
        void Delete(Order order);
    }
}
