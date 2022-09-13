using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Controllers
{
	public class LoanCartController : Controller
	{
		private readonly IBookRepository _bookRepository;
		private readonly LoanCart _loanCart;

		public LoanCartController(IBookRepository bookRepository, LoanCart loanCart)
		{
			_bookRepository = bookRepository;
			_loanCart = loanCart;
		}

		public IActionResult Index()
		{
			_loanCart.LoanCartItems = _loanCart.GetLoanCartItems();
			var loanCartViewModel = new LoanCartViewModel
			{
				LoanCart = _loanCart
			};

			return View(loanCartViewModel);
		}

		public IActionResult AddToLoanCart(int bookId)
        {
			var selectedBook = _bookRepository.GetAllBooks.FirstOrDefault(b => b.BookId == bookId);

            if (selectedBook != null)
            {
				_loanCart.AddToCart(selectedBook, 1);
            }
			return RedirectToAction("Index");
		}

		public RedirectToActionResult RemoveFromLoanCart(int bookId)
		{
			var selectedBook = _bookRepository.GetAllBooks.FirstOrDefault(b => b.BookId == bookId);
			if (selectedBook != null)
			{
				_loanCart.RemoveFromCart(selectedBook);
			}

			return RedirectToAction("Index");
		}

		public RedirectToActionResult ClearCart()
		{
			_loanCart.ClearCart();
			return RedirectToAction("Index");
		}

	}
}
