using System.Collections.Generic;
using CSharp.Data;
using CSharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharp.Controllers{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase{
        private readonly ICustomerRepo _repoCust;
        private readonly IOrderRepo _repoOrder;
        //Dependancy Injection
        public OrderController(ICustomerRepo repoCust, IOrderRepo repoOrder)
        {
            _repoCust = repoCust;
            _repoOrder = repoOrder;
        }

        //GET api/orders
        [HttpGet]
        public ActionResult <IEnumerable<Order>> GetAllOrders(){
            var orders = _repoOrder.GetAllOrders();

            return Ok(orders);
        }

        //GET api/orders/{custId}
        [HttpGet("{custId}", Name = "GetAllOrdersByCustId")]
        public ActionResult <IEnumerable<Order>>  GetAllOrdersByCustId(int custId){
            var orders = _repoOrder.GetAllOrdersByCustId(custId);

            return Ok(orders);
        }

        //POST api/orders
        [HttpPost]
        public ActionResult <Order> CreateOrder(Order order){
            _repoOrder.CreateOrder(order);
            _repoCust.SaveChanges();

            return Ok();
        }

        public ActionResult <Order> GetOrderById(int id){
            var order = _repoOrder.GetOrderById(id);

            return Ok(order);
        }

        //PUT api/orders/{id}
        [HttpPut("{id}")]
        public ActionResult PutOrder(int id, Order order){
            var tempOrder = _repoOrder.GetOrderById(id);
            if(tempOrder == null){
                return NotFound();
            }
            
            _repoOrder.UpdateOrder(order);
            _repoOrder.SaveChanges();

            return NoContent();
        }

        //DELETE api/orders/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id){
            var order = _repoOrder.GetOrderById(id);
            if(order == null){
                return NotFound();
            }
            _repoOrder.DeleteOrder(order);
            _repoOrder.SaveChanges();

            return NoContent();
        }
    }

}