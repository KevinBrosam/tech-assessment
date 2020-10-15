using System.Collections.Generic;
using System.Linq;
using CSharp.Models;

namespace CSharp.Data{
    public class SqlCustomerRepo : ICustomerRepo
    {
        private readonly TechAssessmentContext _context;

        public SqlCustomerRepo(TechAssessmentContext context)
        {
            _context = context;    
        }
        public void CreateCustomer(Customer cust)
        {
            _context.Customers.Add(cust);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}