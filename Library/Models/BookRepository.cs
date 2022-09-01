using System.Collections.Generic;
using System.Linq;

namespace Library.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetAllBooks
        {
            get
            {
                return _context.Books;
            }
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(b => b.BookId == bookId);
        }
    }
}
