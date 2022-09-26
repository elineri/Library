using Library.Models;
using System.Collections.Generic;


namespace Library.ViewModels
{
    public class LoanListViewModel
    {
        public IEnumerable<Loan> Loans { get; set; }

    }
}
