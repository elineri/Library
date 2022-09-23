using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Models
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly LoanCart _loanCart;

        public LoanRepository(LibraryDbContext libraryDbContext, LoanCart loanCart)
        {
            _libraryDbContext = libraryDbContext;
            _loanCart = loanCart;
        }

        public void CreateLoan(Loan loan)
        {
            //loan.LoanDate = DateTime.Now;
            //_libraryDbContext.Loans.Add(loan);
            //_libraryDbContext.SaveChanges();

            //var loanCartItems = _loanCart.GetLoanCartItems();

            //foreach (var loanCartItem in loanCartItems)
            //{
            //    var loanDetails = new LoanDetail
            //    {
            //        LoanId = loan.LoanId,
            //        BookId = loanCartItem.Book.BookId
            //    };

            //    _libraryDbContext.LoanDetails.Add(loanDetails);
            //}

            //_libraryDbContext.SaveChanges();
        }


        //public List<Book> GetCustomerLoans(int id)
        //{
        //    var customerLoanedBooks = (from l in _libraryDbContext.Loans
        //                        join ld in _libraryDbContext.LoanDetails on l.LoanId equals ld.LoanId
        //                        join b in _libraryDbContext.Books on ld.BookId equals b.BookId
        //                        where l.CustomerId == id
        //                        select b).ToList();


        //    return customerLoanedBooks;
        //}
    }
}
