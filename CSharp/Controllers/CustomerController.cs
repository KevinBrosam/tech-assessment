using System.Collections.Generic;
using CSharp.Data;
using CSharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharp.Controllers{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase{
        private readonly ICustomerRepo _repoCust;
        public CustomerController(ICustomerRepo repoCust)
        {
            _repoCust = repoCust;
        }

        /*
        I did not create Data Transfer Objects because of the time constraint
        */

        //GET api/customers
        [HttpGet]
        public ActionResult <IEnumerable<Customer>> GetAllCustomers(){
            var custs = _repoCust.GetAllCustomers();

            return Ok(custs);
        }

        //GET api/customers/{id}
        [HttpGet("{id}", Name = "GetCustomerById")]
        public ActionResult <Customer> GetCustomerById(int id){
            var cust = _repoCust.GetCustomerById(id);
            if(cust != null){
                return Ok(cust);
            }
            return NotFound();
        }

        //POST api/customers
        [HttpPost]
        public ActionResult <Customer> CreateCustomer(Customer cust){
            _repoCust.CreateCustomer(cust);
            _repoCust.SaveChanges();

            return CreatedAtRoute(nameof(GetCustomerById), new {Id = cust.Id}, cust);
        }
    }
}