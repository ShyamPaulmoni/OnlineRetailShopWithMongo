using System.Collections.Generic;
using OnlineRetailStore.ViewModels;

namespace OnlineRetailStore.Models.Interfaces
{
    public interface IOrderServices
    { 
        /// <summary>
        /// Get all placed orders
        /// </summary>
        /// <returns></returns>
        List<Order> GetOrderList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order GetOrder(int orderId);
        ProductViewModel AddOrder(Order orderModel);
        ProductViewModel DeleteOrder(int orderId);

    }
}
