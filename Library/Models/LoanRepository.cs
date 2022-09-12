using System;

namespace Library.Models
{
    public class LoanRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public LoanRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public void CreateLoan(Loan loan)
        {
            loan.LoanDate = DateTime.Now;
            _libraryDbContext.Loans.Add(loan);
            _libraryDbContext.SaveChanges();

            var loanDetails = new Loan
            {
                ReturnDate = loan.LoanDate.AddDays(30),
                IsReturned = false
            };
        }
    }
}
