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
        private readonly LoanCart _loanCart;
        private readonly LibraryDbContext _libraryDbContext;

        public LoanController(ILoanRepository loanRepository, LoanCart loanCart, LibraryDbContext libraryDbContext)
        {
            _loanRepository = loanRepository;
            _loanCart = loanCart;
            _libraryDbContext = libraryDbContext;
        }

        public IActionResult Checkout(Loan loan)
        {
            _loanCart.LoanCartItems = _loanCart.GetLoanCartItems();

            if (_loanCart.LoanCartItems.Count == 0)
            {
                ModelState.AddModelError("", "You haven't added any books");
            }

            if (ModelState.IsValid)
            {
                _loanRepository.CreateLoan(loan);
                _loanCart.ClearCart();

                return RedirectToAction("CheckoutComplete");
            }
            return View(loan);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for your loan";
            return View();
        }

        

        public IActionResult List(int id)
        {
            //var customerLoans = _loanRepository.GetCustomerLoans(id);

            //var customerLoanedBooks = _loanRepository.GetCustomerLoans(id);
            var loans = _libraryDbContext.Loans.Include(b => b.Book).Where(c => c.CustomerId == id);

            //var books = (from l in _libraryDbContext.Loans
            //            join b in _libraryDbContext.Books on l.BookId equals b.BookId
            //            where l.CustomerId == id
            //            select b.Title).ToList();

            

            var loanListViewModel = new LoanListViewModel
            {
                Loans = loans
                //LoanedBooks = customerLoanedBooks,
                //Loan = _libraryDbContext.Loans.FirstOrDefault(c => c.CustomerId == id)
            };
            return View(loanListViewModel);
        }
    }
}
