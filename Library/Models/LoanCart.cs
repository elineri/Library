using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Models
{
	public class LoanCart
	{
		private readonly LibraryDbContext _libraryDbContext;

		public string CartId { get; set; }

		public List<LoanCartItem> LoanCartItems { get; set; }

		public LoanCart(LibraryDbContext libraryDbContext)
		{
			_libraryDbContext = libraryDbContext;
		}

		public static LoanCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<LibraryDbContext>();

			string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
			session.SetString("CartId", cartId);

			return new LoanCart(context) { CartId = cartId };
		}

		public void AddToCart(Book book, int amount)
		{
			var LoanCartItem = _libraryDbContext.LoanCartItems.SingleOrDefault(b => b.Book.BookId == book.BookId
			&& b.LoanCartId == CartId);

			if (LoanCartItem == null)
			{
				LoanCartItem = new LoanCartItem
				{
					LoanCartId = CartId,
					Book = book,
					Amount = amount
				};
				_libraryDbContext.LoanCartItems.Add(LoanCartItem);
			}
			else
			{
				LoanCartItem.Amount++;
			}
			_libraryDbContext.SaveChanges();
		}

		public int RemoveFromCart(Book book)
		{
			var LoanCartItem = _libraryDbContext.LoanCartItems.SingleOrDefault(b => b.Book.BookId == book.BookId
			&& b.LoanCartId == CartId);

			var localAmount = 0;
			if (LoanCartItem != null)
			{
				if (LoanCartItem.Amount > 1)
				{
					LoanCartItem.Amount--;
					localAmount = LoanCartItem.Amount;
				}
				else
				{
					_libraryDbContext.LoanCartItems.Remove(LoanCartItem);
				}
			}

			_libraryDbContext.SaveChanges();
			return localAmount;
		}

		public List<LoanCartItem> GetLoanCartItems()
		{
			return LoanCartItems ?? (LoanCartItems = _libraryDbContext.LoanCartItems.
				Where(b => b.LoanCartId == CartId).
				Include(b => b.Book).ToList());
		}

		public void ClearCart()
		{
			var cartItems = _libraryDbContext.LoanCartItems.Where(c => c.LoanCartId == CartId);
			_libraryDbContext.LoanCartItems.RemoveRange(cartItems);
			_libraryDbContext.SaveChanges();
		}

	}
}
