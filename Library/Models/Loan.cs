using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Loan
    {
        [BindNever]
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime LoanDate { get; set; }

        //TODO: Add Return date .AddDays

        public bool IsReturned { get; set; }        
    }
}
