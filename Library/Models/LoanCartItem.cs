using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
	public class LoanCartItem
	{
		[Key]
		public int LoanCartItemId { get; set; }
		public string LoanCartId { get; set; }
		public Book Book { get; set; }
		public int Amount { get; set; }

	}
}
