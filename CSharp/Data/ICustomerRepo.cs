using System.Collections.Generic;
using CSharp.Models;

namespace CSharp.Data{
    public interface ICustomerRepo{
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer cust);
        bool SaveChanges();
    }
}