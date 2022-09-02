using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly LibraryDbContext _context;

        public CustomerController(ICustomerRepository customerRepository, LibraryDbContext context)
        {
            _customerRepository = customerRepository;
            _context = context;
        }

        public ViewResult List()
        {
            return View(_customerRepository.GetAllCustomers);
        }
        public IActionResult Details(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult AddOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Customer());
            }
            else
            {
                return View(_customerRepository.GetCustomerById(id));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit([Bind("CustomerId, FirstName, LastName, PhoneNumber, Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customerToDelete = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customerToDelete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
