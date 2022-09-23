using System.Collections.Generic;
using System.Linq;

namespace Library.Models
{
    public interface ILoanRepository
    {
        //IEnumerable<Book> GetCustomerLoans(int id);
        void CreateLoan(Loan loan);
    }
}
