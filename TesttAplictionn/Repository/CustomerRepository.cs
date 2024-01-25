using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesttAplictionn.Interface;
using TesttAplictionn.Models;

namespace TesttAplictionn.Repository
{
    public class CustomerRepository : ICustomerRepository
    {


        private readonly TesttDBContext _context;

        public CustomerRepository(TesttDBContext context)
        {
            _context = context;
        }


        public void DeleteCustomer(int CustomerId)
        {
            Customer customer = _context.Customers.Find(CustomerId);
            _context.Customers.Remove(customer);
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int CustomerId)
        {
            return _context.Customers.Find(CustomerId);
        }

        public void InsertCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void SaveCustomer()
        {
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
