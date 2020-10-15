using System.Collections.Generic;
using CSharp.Models;

namespace CSharp.Data{
    public interface IOrderRepo{
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetAllOrdersByCustId(int custId);
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        void SaveChanges();
    }
}