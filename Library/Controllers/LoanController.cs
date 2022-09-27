using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class LoanController : Controller
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;


        public LoanController(LibraryDbContext libraryDbContext, IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _libraryDbContext = libraryDbContext;
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult NewLoan(int bookId)
        {
            var selectedBook = _bookRepository.GetBookById(bookId);

            var loan = new Loan
            {
                BookId = selectedBook.BookId
            };

            var newLoanViewModel = new NewLoanViewModel
            {
                Customers = _customerRepository.GetAllCustomers,
                Loan = loan,
                Book = selectedBook
            };

            return View(newLoanViewModel); 
        }

        [HttpPost]
        public ViewResult NewLoan(NewLoanViewModel newLoanViewModel)
        {
            return View(_customerRepository.GetAllCustomers);
        }

        public IActionResult Checkout(Loan loan)
        {
            loan.IsReturned = false;
            loan.LoanDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _libraryDbContext.Loans.Add(loan);
                _libraryDbContext.SaveChanges();
            }
            return View("CheckoutComplete");
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }

        
        // List of customer loans
        public IActionResult List(int id)
        {
            var loans = _libraryDbContext.Loans.Include(b => b.Book).Where(c => c.CustomerId == id);            

            var loanListViewModel = new LoanListViewModel
            {
                Loans = loans
            };
            return View(loanListViewModel);
        }      
    }
}
