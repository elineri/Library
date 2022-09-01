using System.Collections.Generic;

namespace Library.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers { get; }
        Customer GetCustomerById(int customerId);
    }
}
