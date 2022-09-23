using System.Collections.Generic;
using System.Linq;

namespace Library.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers { get; }
        Customer GetCustomerById(int customerId);
    }
}
