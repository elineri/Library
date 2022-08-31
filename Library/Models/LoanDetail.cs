using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class LoanDetail
    {
        [Key]
        public int LoanDetailId { get; set; }
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
