using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Models
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _libraryDbContext;
        //private readonly LoanCart _loanCart;

        public LoanRepository(LibraryDbContext libraryDbContext /*LoanCart loanCart*/)
        {
            _libraryDbContext = libraryDbContext;
            //_loanCart = loanCart;
        }

        //public void CreateLoan(Loan loan)
        //{
        //    _libraryDbContext.Loans.Add(loan);
        //    _libraryDbContext.SaveChanges();

        //    var loanDetails = new Loan
        //    {
        //        CustomerId = loan.CustomerId,
        //        BookId = loan.BookId,
        //        LoanDate = DateTime.Now,
        //        IsReturned = false
        //    };

        //    _libraryDbContext.Loans.Add(loanDetails);
        //    _libraryDbContext.SaveChanges();

        //}

    }
}
