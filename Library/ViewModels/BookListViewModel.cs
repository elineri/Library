using Library.Models;
using System.Collections.Generic;

namespace Library.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
