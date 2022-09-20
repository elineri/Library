using Library.Models;
using Microsoft.AspNetCore.Mvc;
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

        public LoanController(ILoanRepository loanRepository, LoanCart loanCart)
        {
            _loanRepository = loanRepository;
            _loanCart = loanCart;
        }

        //public IActionResult Checkout()
        //{
        //    return View();
        //}

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
    }
}
