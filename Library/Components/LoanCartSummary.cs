using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Components
{
    public class LoanCartSummary : ViewComponent
    {
        private readonly LoanCart _loanCart;

        public LoanCartSummary(LoanCart loanCart)
        {
            _loanCart = loanCart;
        }

        public IViewComponentResult Invoke()
        {
            _loanCart.LoanCartItems = _loanCart.GetLoanCartItems();

            var loanCartViewModels = new LoanCartViewModel
            {
                LoanCart = _loanCart,
            };

            return View(loanCartViewModels);
        }
    }
}
