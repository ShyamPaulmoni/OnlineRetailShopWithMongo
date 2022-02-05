using System.Collections.Generic;
using OnlineRetailStore.Models;

namespace OnlineRetailStore.Repository.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product Get(int id);
        List<Product> GetAll();
        void Update(Product product);
        void Delete(Product product);
    }
}
