using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Models;

namespace CSharp.Data{
    public class SqlOrderRepo : IOrderRepo
    {
        private readonly TechAssessmentContext _context;

        public SqlOrderRepo(TechAssessmentContext context)
        {
            _context = context;
        }
        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            if(order == null){
                throw new ArgumentNullException(nameof(order));
            }
            _context.Remove(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetAllOrdersByCustId(int custId)
        {
            return _context.Orders.ToList().Where(o => o.CustomerId == custId);
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(p => p.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            var newOrder = GetOrderById(order.Id);
            _context.Entry(newOrder).CurrentValues.SetValues(order);
        }
    }
}