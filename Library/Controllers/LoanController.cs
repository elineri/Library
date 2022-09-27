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
        private readonly ILoanRepository _loanRepository;
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;


        public LoanController(ILoanRepository loanRepository, LibraryDbContext libraryDbContext, IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _loanRepository = loanRepository;
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

            //_libraryDbContext.Add(loan);
            //_libraryDbContext.SaveChanges();

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
            //loan.IsReturned = false;
            //loan.LoanDate = DateTime.Now;

            loan.IsReturned = false;
            loan.LoanDate = DateTime.Now;

            //var loanedBook = new Loan
            //{
            //    CustomerId = loan.CustomerId,
            //    BookId = loan.BookId,
            //    LoanDate = DateTime.Now,
            //    IsReturned = false            
            //};

            if (ModelState.IsValid)
            {
                //_loanRepository.CreateLoan(loan);
                //_loanCart.ClearCart();
                _libraryDbContext.Loans.Add(loan);
                _libraryDbContext.SaveChanges();
                //return RedirectToAction("Checkout");
            }
            return View("CheckoutComplete");
        }

        //public void CreateLoan(Loan loan)
        //{
        //    var loanedBook = new Loan
        //    {
        //        LoanId = loan.LoanId,
        //        CustomerId = loan.CustomerId,
        //        BookId = loan.BookId,
        //        LoanDate = DateTime.Now,
        //        IsReturned = false
        //    };

        //    _libraryDbContext.Loans.Add(loanedBook);
        //    _libraryDbContext.SaveChanges();
        //}

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

        //public void CreateLoan(Loan loan)
        //{

        //    var loanCartItems = _loanCart.GetLoanCartItems();

        //    foreach (var loanCartItem in loanCartItems)
        //    {
        //        var loanedBook = new Loan
        //        {
        //            LoanId = loan.LoanId,
        //            CustomerId = loan.CustomerId,
        //            BookId = loan.BookId,
        //            LoanDate = DateTime.Now,
        //            IsReturned = false
        //        };

        //        _libraryDbContext.Loans.Add(loanedBook);
        //        _libraryDbContext.SaveChanges();
        //    }

        //}

        

    }
}
