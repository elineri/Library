using System.Collections.Generic;

namespace Library.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks { get; }
        Book GetBookById(int bookId);
    }
}
