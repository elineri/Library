using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LibraryDbContext _context;
        public CustomerRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAllCustomers
        {
            get
            {
                return _context.Customers;
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            var customerDetails = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
