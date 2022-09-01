using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public List<LoanDetail> LoanDetails { get; set; }
        
    }
}
