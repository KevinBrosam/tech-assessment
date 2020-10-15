using CSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp.Data{
    public class TechAssessmentContext : DbContext{
        public TechAssessmentContext(DbContextOptions<TechAssessmentContext> opt) : base(opt){

        }

        public DbSet<Customer> Customers{get;set;}
        public DbSet<Order> Orders{get;set;}
    }
}