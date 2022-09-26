using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class NewLoanViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public Loan Loan { get; set; }
        public Book Book { get; set; }
    }
}
